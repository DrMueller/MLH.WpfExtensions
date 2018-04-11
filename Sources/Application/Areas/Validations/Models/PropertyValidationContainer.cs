using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.WpfExtensions.Areas.Validations.ValidationExpressions;

namespace Mmu.Mlh.WpfExtensions.Areas.Validations.Models
{
    public class PropertyValidationContainer
    {
        private readonly List<PropertyValidation> _entries;
        private readonly ValidationErrors _validationErrors;

        public PropertyValidationContainer()
        {
            _entries = new List<PropertyValidation>();
            _validationErrors = new ValidationErrors();
        }

        public bool HasErrors => _validationErrors.HasErrors;

        public void AddExpressionForProperty(string propertyName, IValidationExpression expression)
        {
            _entries.Add(new PropertyValidation(propertyName, expression));
        }

        public IReadOnlyCollection<string> GetValidationErrorMessages(string propertyName, object value)
        {
            var propertyValidations = _entries.Where(f => f.PropertyName == propertyName);
            var validationResults = propertyValidations.Select(f => f.Validate(value)).ToList();
            var invalidResultErrorMessages = validationResults.Where(f => !f.IsValid).Select(f => f.ErrorMessage).ToList();
            _validationErrors.UpdateErrors(propertyName, invalidResultErrorMessages);
            return invalidResultErrorMessages;
        }
    }
}