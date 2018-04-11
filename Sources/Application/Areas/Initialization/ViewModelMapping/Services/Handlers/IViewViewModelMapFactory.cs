using System.Collections.Generic;
using System.Reflection;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.ViewModelMapping.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.Initialization.ViewModelMapping.Services.Handlers
{
    internal interface IViewViewModelMapFactory
    {
        IReadOnlyCollection<ViewViewModelMap> CreateAllMaps(Assembly rootAssembly);
    }
}