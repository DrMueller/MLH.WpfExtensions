using System;
using System.ComponentModel;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.Validations.Configuration.Models;
using Mmu.Mlh.WpfExtensions.Areas.Validations.Validation.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.Validations.Configuration.Services.Implementation
{
    public class ValidationConfigurationBuilder : IValidationConfigurationBuilder
    {
        private readonly ValidationConfiguration _validationConfiguration;

        public ValidationConfigurationBuilder() => _validationConfiguration = new ValidationConfiguration();

        internal ValidationContainer BuildContainer(
            EventHandler<DataErrorsChangedEventArgs> errorsChanged,
            ViewModelWithValidation viewModel)
        {
            var propertyValidations = _validationConfiguration.BuildPropertyValidations();
            var result = new ValidationContainer(propertyValidations, errorsChanged, viewModel);

            return result;
        }

        public IPropertyValidationConfigurationBuilder ForProperty(string propertyName)
        {
            var propConfig = new PropertyValidationConfiguration(propertyName);
            _validationConfiguration.Add(propConfig);
            var builder = new PropertyValidationConfigurationBuilder(this, propConfig);
            return builder;
        }
    }
}