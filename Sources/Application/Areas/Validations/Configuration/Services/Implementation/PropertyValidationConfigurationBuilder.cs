using Mmu.Mlh.WpfExtensions.Areas.Validations.Configuration.Models;
using Mmu.Mlh.WpfExtensions.Areas.Validations.ValidationExpressions;

namespace Mmu.Mlh.WpfExtensions.Areas.Validations.Configuration.Services.Implementation
{
    public class PropertyValidationConfigurationBuilder : IPropertyValidationConfigurationBuilder
    {
        private readonly PropertyValidationConfiguration _propertyValidationConfig;

        private readonly IValidationConfigurationBuilder _validationConfigBuilder;

        internal PropertyValidationConfigurationBuilder(
            IValidationConfigurationBuilder validationConfigBuilder,
            PropertyValidationConfiguration propertyValidationConfig)
        {
            _validationConfigBuilder = validationConfigBuilder;
            _propertyValidationConfig = propertyValidationConfig;
        }

        public IPropertyValidationConfigurationBuilder AddExpression(IValidationExpression expression)
        {
            _propertyValidationConfig.AddExpression(expression);
            return this;
        }

        public IValidationConfigurationBuilder BuildPropertyValidation() => _validationConfigBuilder;
    }
}