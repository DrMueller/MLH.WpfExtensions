using Mmu.Mlh.WpfExtensions.Areas.Validations.Validation.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.Validations.ValidationExpressions.CoreValidationExpressions
{
    public class StringLengthExpression : IValidationExpression
    {
        private readonly int _maxLength;
        private readonly int _minLength;

        public StringLengthExpression(int minLength, int maxLength)
        {
            _minLength = minLength;
            _maxLength = maxLength;
        }

        public ValidationResult Validate(object value)
        {
            var str = value?.ToString();
            if (string.IsNullOrEmpty(str) || str.Length < _minLength || str.Length > _maxLength)
            {
                return ValidationResult.CreateInvalid($"String must be between {_minLength} and {_maxLength} characters.");
            }

            return ValidationResult.CreateValid();
        }
    }
}