using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mmu.Mlh.LanguageExtensions.Areas.Reflection.Implementation;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.ViewModelMapping.Models;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.Initialization.ViewModelMapping.Services.Handlers.Implementation
{
    internal class ViewViewModelMapFactory : IViewViewModelMapFactory
    {
        ////private readonly ITypeReflectionService _typeReflectionService;

        ////public ViewViewModelMapFactory(ITypeReflectionService typeReflectionService)
        ////{
        ////    _typeReflectionService = typeReflectionService;
        ////}
        private static readonly Type _viewModelMapType = typeof(IViewMap<>);

        public IReadOnlyCollection<ViewViewModelMap> CreateAllMaps(Assembly rootAssembly)
        {
            var viewMapTypes = GetViewMapTypes(rootAssembly);
            var result = viewMapTypes.Select(CreateFromViewMapType).ToList();
            return result;
        }

        private static ViewViewModelMap CreateFromViewMapType(Type viewMapType)
        {
            var tmp = new TypeReflectionService();

            var mapInterface = viewMapType.GetInterfaces().First(f => tmp.CheckIfTypeIsAssignableToGenericType(f, _viewModelMapType));

            var viewModelType = mapInterface.GetGenericArguments().First();
            return new ViewViewModelMap(viewMapType, viewModelType);
        }

        private static IEnumerable<Type> GetViewMapTypes(Assembly rootAssembly)
        {
            var tmp = new TypeReflectionService();

            var result = rootAssembly.GetTypes().Where(
                f =>
                    tmp.CheckIfTypeIsAssignableToGenericType(f, _viewModelMapType)
                    && !f.IsInterface
                    && !f.IsAbstract).ToList();
            return result;
        }
    }
}