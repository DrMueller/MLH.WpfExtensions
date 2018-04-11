using Mmu.Mlh.WpfExtensions.Areas.Validations.ValidationExpressions;

namespace Mmu.Mlh.WpfExtensions.Areas.Validations.Models
{
    public class PropertyValidation
    {
        private readonly IValidationExpression _expression;

        public PropertyValidation(string propertyName, IValidationExpression expression)
        {
            _expression = expression;
            PropertyName = propertyName;
            PropertyName = propertyName;
        }

        public string PropertyName { get; }

        public ValidationResult Validate(object value) => _expression.Validate(value);
    }
}