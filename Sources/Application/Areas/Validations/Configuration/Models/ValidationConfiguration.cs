using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.WpfExtensions.Areas.Validations.Validation.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.Validations.Configuration.Models
{
    public class ValidationConfiguration
    {
        private IList<PropertyValidationConfiguration> _propertyValidationConfigurations;

        public ValidationConfiguration()
        {
            _propertyValidationConfigurations = new List<PropertyValidationConfiguration>();
        }

        public void Add(PropertyValidationConfiguration config)
        {
            _propertyValidationConfigurations.Add(config);
        }

        internal IDictionary<string, PropertyValidation> BuildPropertyValidations()
        {
            return _propertyValidationConfigurations
                .Select(f => f.BuildPropertyValidation())
                .ToDictionary(f => f.PropertyName, f => f);
        }
    }
}