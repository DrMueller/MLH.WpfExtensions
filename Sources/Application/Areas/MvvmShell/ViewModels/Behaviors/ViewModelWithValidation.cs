using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Mlh.WpfExtensions.Areas.Validations.Configuration.Services;
using Mmu.Mlh.WpfExtensions.Areas.Validations.Configuration.Services.Implementation;
using Mmu.Mlh.WpfExtensions.Areas.Validations.Validation.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors
{
    public abstract class ViewModelWithValidation : ViewModelBase, INotifyDataErrorInfo, IInitializableViewModel
    {
        private ValidationContainer _validationContainer;

        public bool HasErrors => _validationContainer.HasErrors;

        public IEnumerable GetErrors(string propertyName) => _validationContainer.GetErrorMessages(propertyName);

        public async Task InitializeAsync()
        {
            InitializeValidation();
            await InitializeAsnc();
        }

        protected abstract void ConfigureValidation(IValidationConfigurationBuilder builder);

        protected virtual Task InitializeAsnc() => Task.FromResult<object>(null);

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            _validationContainer.Validate(propertyName);
        }

        private void InitializeValidation()
        {
            var builder = new ValidationConfigurationBuilder();
            ConfigureValidation(builder);
            _validationContainer = builder.BuildContainer(ErrorsChanged, this);
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    }
}