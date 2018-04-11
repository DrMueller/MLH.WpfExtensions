using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Mlh.WpfExtensions.Areas.Validations.ValidationExpressions;

namespace Mmu.Mlh.WpfExtensions.Areas.Validations.Models
{
    public class ValidationContainer
    {
        private readonly EventHandler<DataErrorsChangedEventArgs> _errorsChanged;
        private readonly ViewModelBase _viewModel;
        private PropertyValidationContainer _propertyValidationContainer;

        public ValidationContainer(EventHandler<DataErrorsChangedEventArgs> errorsChanged, ViewModelBase viewModel)
        {
            _errorsChanged = errorsChanged;
            _viewModel = viewModel;
            _propertyValidationContainer = new PropertyValidationContainer();
        }

        public bool HasErrors => _propertyValidationContainer.HasErrors;

        public void AddValidation(string propertyName, IValidationExpression expression)
        {
            _propertyValidationContainer.AddExpressionForProperty(propertyName, expression);
        }

        public IReadOnlyCollection<string> GetErrorMessages(string propertyName)
        {
            var propertyValue = _viewModel.GetType().GetProperty(propertyName)?.GetValue(_viewModel);
            var validationErrorMessages = _propertyValidationContainer.GetValidationErrorMessages(propertyName, propertyValue);
            return validationErrorMessages;
        }

        public void Validate([CallerMemberName] string propertyName = null)
        {
            if (GetErrorMessages(propertyName).Any())
            {
                OnErrorsChanged(propertyName);
            }
        }

        private void OnErrorsChanged([CallerMemberName] string propertyName = null)
        {
            _errorsChanged?.Invoke(_viewModel, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}