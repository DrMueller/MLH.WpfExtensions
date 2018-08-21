using System.Diagnostics.CodeAnalysis;
using Mmu.Mlh.WpfExtensions.Areas.InformationHandling.Services;
using Mmu.Mlh.WpfExtensions.Areas.InformationHandling.Services.Implementation;
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
using Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Dialogs.FileDialogs.Services;
using Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Dialogs.FileDialogs.Services.Implementation;
using Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Dialogs.FolderDialogs.Services;
using Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Dialogs.FolderDialogs.Services.Implementation;
using StructureMap;

namespace Mmu.Mlh.WpfExtensions.Infrastructure.DependencyInjection
{
    public class WpfExtensionsRegistry : Registry
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Central registry")]
        public WpfExtensionsRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<WpfExtensionsRegistry>();
                    scanner.AddAllTypesOf<IViewModel>();
                    scanner.WithDefaultConventions();
                });

            // Appearance
            For<IAppearanceService>().Use<AppearanceService>().Singleton();
            For<IRegistryHandler>().Use<RegistryHandler>();

            // AppStart
            For<IAppStartService>().Use<AppStartService>();
            For<IViewModelMappingService>().Use<ViewModelMappingService>();
            For<IResourceDictionaryFactory>().Use<ResourceDictionaryFactory>();
            For<IMaterialDesignInitializationService>().Use<MaterialDesignInitializationService>();
            For<IDataTemplateFactory>().Use<DataTemplateFactory>();
            For<IViewViewModelMapFactory>().Use<ViewViewModelMapFactory>();

            // Dialogs
            For<IFileDialogService>().Use<FileDialogService>();
            For<IFolderDialogService>().Use<FolderDialogService>();

            // Information handling
            For<IInformationSubscriptionViewService>().Use<InformationSubscriptionViewService>();

            // Navigation
            For<IMainNavigationEntryFactory>().Use<MainNavigationEntryFactory>();
            For<INavigationConfigurationService>().Use<NavigationConfigurationService>().Singleton();
            For<INavigationService>().Use<NavigationService>().Singleton();
        }
    }
}