using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.WpfExtensions.Areas.Validations.ValidationExpressions;

namespace Mmu.Mlh.WpfExtensions.Areas.Validations.Validation.Models
{
    public class PropertyValidation
    {
        private readonly IReadOnlyCollection<IValidationExpression> _expressions;
        public string PropertyName { get; }

        public PropertyValidation(string propertyName, IReadOnlyCollection<IValidationExpression> expressions)
        {
            _expressions = expressions;
            PropertyName = propertyName;
        }

        public IReadOnlyCollection<ValidationResult> Validate(object value)
        {
            return _expressions.Select(f => f.Validate(value)).ToList();
        }
    }
}