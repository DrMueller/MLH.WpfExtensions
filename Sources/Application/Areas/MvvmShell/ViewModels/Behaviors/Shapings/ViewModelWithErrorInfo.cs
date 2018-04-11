using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Mlh.WpfExtensions.Areas.Validations.Models;
using Mmu.Mlh.WpfExtensions.Areas.Validations.ValidationExpressions;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors.Shapings
{
    public abstract class ViewModelWithErrorInfo : ViewModelBase, INotifyDataErrorInfo, IViewModelWithBehaviorBase
    {
        private readonly ValidationContainer _validationContainer;

        protected ViewModelWithErrorInfo()
        {
            _validationContainer = new ValidationContainer(ErrorsChanged, this);
        }

        public bool HasErrors => _validationContainer.HasErrors;

        public IEnumerable GetErrors(string propertyName) => _validationContainer.GetErrorMessages(propertyName);

        protected void AddValidation(string propertyName, IValidationExpression expression)
        {
            _validationContainer.AddValidation(propertyName, expression);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            _validationContainer.Validate(propertyName);
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    }
}