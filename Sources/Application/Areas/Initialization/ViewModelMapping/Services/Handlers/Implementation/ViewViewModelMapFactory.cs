using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mmu.Mlh.LanguageExtensions.Areas.Reflection;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.ViewModelMapping.Models;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.Initialization.ViewModelMapping.Services.Handlers.Implementation
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StructureMap")]
    internal class ViewViewModelMapFactory : IViewViewModelMapFactory
    {
        private static readonly Type _viewModelMapType = typeof(IViewMap<>);
        private readonly ITypeReflectionService _typeReflectionService;

        public ViewViewModelMapFactory(ITypeReflectionService typeReflectionService)
        {
            _typeReflectionService = typeReflectionService;
        }

        public IReadOnlyCollection<ViewViewModelMap> CreateAllMaps(Assembly rootAssembly)
        {
            var viewMapTypes = GetViewMapTypes(rootAssembly);
            var result = viewMapTypes.Select(CreateFromViewMapType).ToList();
            return result;
        }

        private ViewViewModelMap CreateFromViewMapType(Type viewMapType)
        {
            var mapInterface = viewMapType.GetInterfaces().First(f => _typeReflectionService.CheckIfTypeIsAssignableToGenericType(f, _viewModelMapType));

            var viewModelType = mapInterface.GetGenericArguments().First();
            return new ViewViewModelMap(viewMapType, viewModelType);
        }

        private IEnumerable<Type> GetViewMapTypes(Assembly rootAssembly)
        {
            var result = rootAssembly.GetTypes().Where(
                f =>
                    _typeReflectionService.CheckIfTypeIsAssignableToGenericType(f, _viewModelMapType)
                    && !f.IsInterface
                    && !f.IsAbstract).ToList();
            return result;
        }
    }
}