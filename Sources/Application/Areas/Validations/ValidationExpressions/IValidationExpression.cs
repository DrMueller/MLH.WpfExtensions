using Mmu.Mlh.WpfExtensions.Areas.Validations.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.Validations.ValidationExpressions
{
    public interface IValidationExpression
    {
        ValidationResult Validate(object value);
    }
}