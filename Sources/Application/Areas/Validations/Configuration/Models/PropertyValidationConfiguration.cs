using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.WpfExtensions.Areas.Validations.Validation.Models;
using Mmu.Mlh.WpfExtensions.Areas.Validations.ValidationExpressions;

namespace Mmu.Mlh.WpfExtensions.Areas.Validations.Configuration.Models
{
    public class PropertyValidationConfiguration
    {
        private readonly List<IValidationExpression> _expressions;
        private readonly string _propertyName;

        public PropertyValidationConfiguration(string propertyName)
        {
            Guard.ObjectNotNull(() => propertyName);
            _propertyName = propertyName;
            _expressions = new List<IValidationExpression>();
        }

        public void AddExpression(IValidationExpression expression)
        {
            _expressions.Add(expression);
        }

        internal PropertyValidation BuildPropertyValidation() => new PropertyValidation(_propertyName, _expressions);
    }
}