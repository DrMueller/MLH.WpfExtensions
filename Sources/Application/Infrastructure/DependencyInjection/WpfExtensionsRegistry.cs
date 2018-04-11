using Mmu.Mlh.WpfExtensions.Areas.Initialization.AppStart;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.AppStart.Implementation;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.MaterialDesign;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.MaterialDesign.Handlers;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.MaterialDesign.Handlers.Implementation;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.MaterialDesign.Implementation;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.ViewModelMapping.Services;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.ViewModelMapping.Services.Handlers;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.ViewModelMapping.Services.Handlers.Implementation;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.ViewModelMapping.Services.Implementation;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Appearance.Services;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Appearance.Services.Handlers;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Appearance.Services.Handlers.Implementation;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Appearance.Services.Implementation;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Mlh.WpfExtensions.Areas.Navigation.Services;
using Mmu.Mlh.WpfExtensions.Areas.Navigation.Services.Implementation;
using StructureMap;

namespace Mmu.Mlh.WpfExtensions.Infrastructure.DependencyInjection
{
    public class WpfExtensionsRegistry : Registry
    {
        public WpfExtensionsRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<WpfExtensionsRegistry>();
                    scanner.AddAllTypesOf<IViewModel>();
                    scanner.WithDefaultConventions();
                });

            For<IAppStartService>().Use<AppStartService>();
            For<IViewModelMappingService>().Use<ViewModelMappingService>();

            For<IResourceDictionaryFactory>().Use<ResourceDictionaryFactory>();
            For<IMaterialDesignInitializationService>().Use<MaterialDesignInitializationService>();
            For<IDataTemplateFactory>().Use<DataTemplateFactory>();
            For<IViewViewModelMapFactory>().Use<ViewViewModelMapFactory>();
            For<IMainNavigationEntryFactory>().Use<MainNavigationEntryFactory>();
            For<INavigationConfigurationService>().Use<NavigationConfigurationService>();
            For<INavigationService>().Use<NavigationService>();

            For<IAppearanceService>().Use<AppearanceService>().Singleton();
            For<IRegistryHandler>().Use<RegistryHandler>();
        }
    }
}