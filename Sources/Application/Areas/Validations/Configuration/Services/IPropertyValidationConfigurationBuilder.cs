using Mmu.Mlh.WpfExtensions.Areas.Validations.ValidationExpressions;

namespace Mmu.Mlh.WpfExtensions.Areas.Validations.Configuration.Services
{
    public interface IPropertyValidationConfigurationBuilder
    {
        IPropertyValidationConfigurationBuilder AddExpression(IValidationExpression expression);

        IValidationConfigurationBuilder BuildPropertyValidation();
    }
}