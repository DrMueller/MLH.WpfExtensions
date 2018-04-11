using System;

namespace Mmu.Mlh.WpfExtensions.Areas.Initialization.ViewModelMapping.Models
{
    internal class TypeWithNormalizedName
    {
        public TypeWithNormalizedName(Type type, string normalizedName)
        {
            Type = type;
            NormalizedName = normalizedName;
        }

        public string NormalizedName { get; }
        public Type Type { get; }
    }
}