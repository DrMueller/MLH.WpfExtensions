using Mmu.Mlh.WpfExtensions.Areas.Validations.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.Validations.ValidationExpressions.CoreValidationExpressions
{
    public class StringNotNullOrEmptyValidationExpression : IValidationExpression
    {
        public ValidationResult Validate(object value)
        {
            var str = value?.ToString();
            return string.IsNullOrEmpty(str) ? ValidationResult.CreateInvalid("String must not be null or empty.") : ValidationResult.CreateValid();
        }
    }
}