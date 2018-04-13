using Mmu.Mlh.WpfExtensions.Areas.Validations.Validation.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.Validations.ValidationExpressions.CoreValidationExpressions
{
    public class StringNotNullOrEmptyExpression : IValidationExpression
    {
        public ValidationResult Validate(object value)
        {
            var str = value?.ToString();
            return string.IsNullOrEmpty(str) ? ValidationResult.CreateInvalid("String must not be null or empty.") : ValidationResult.CreateValid();
        }
    }
}