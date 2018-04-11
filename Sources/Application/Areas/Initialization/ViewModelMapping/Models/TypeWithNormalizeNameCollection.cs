using System.Collections.Generic;
using System.Linq;

namespace Mmu.Mlh.WpfExtensions.Areas.Initialization.ViewModelMapping.Models
{
    internal class TypeWithNormalizedNameCollection : List<TypeWithNormalizedName>
    {
        public TypeWithNormalizedName this[string normalizedName]
        {
            get
            {
                return this.First(f => f.NormalizedName == normalizedName);
            }
        }
    }
}