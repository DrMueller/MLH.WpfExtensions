using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.Validations.Validation.Models
{
    public class ValidationContainer
    {
        private readonly IDictionary<string, PropertyValidation> _entries;
        private EventHandler<DataErrorsChangedEventArgs> _errorsChanged;
        private IViewModel _viewModel;

        internal ValidationContainer(
            IDictionary<string, PropertyValidation> entries,
            EventHandler<DataErrorsChangedEventArgs> errorsChanged,
            IViewModel viewModel)
        {
            _entries = entries;
            _errorsChanged = errorsChanged;
            _viewModel = viewModel;
        }

        public bool HasErrors { get; private set; }

        public IReadOnlyCollection<string> GetErrorMessages(string propertyName)
        {
            var propertyValue = _viewModel.GetType().GetProperty(propertyName)?.GetValue(_viewModel);
            return GetValidationErrorMessages(propertyName, propertyValue);
        }

        public void Validate(string propertyName)
        {
            if (GetErrorMessages(propertyName).Any())
            {
                OnErrorsChanged(propertyName);
            }
        }

        private IReadOnlyCollection<string> GetValidationErrorMessages(string propertyName, object value)
        {
            var validationErrors = _entries[propertyName]
                .Validate(value)
                .Where(f => !f.IsValid)
                .Select(f => f.ErrorMessage)
                .ToList();

            HasErrors = validationErrors.Any();
            return validationErrors;
        }

        private void OnErrorsChanged([CallerMemberName] string propertyName = null)
        {
            _errorsChanged?.Invoke(_viewModel, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}