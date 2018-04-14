using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Threading.Tasks;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.MaterialDesign;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.ViewModelMapping.Services;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.ViewModels;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Views;

namespace Mmu.Mlh.WpfExtensions.Areas.Initialization.AppStart.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StructureMap")]
    internal class AppStartService : IAppStartService
    {
        private readonly IMaterialDesignInitializationService _materialDesignInitializationService;
        private readonly ViewModelContainer _viewModelContainer;
        private readonly IViewModelMappingService _viewModelMappingService;

        public AppStartService(
            ViewModelContainer viewModelContainer,
            IViewModelMappingService viewModelMappingService,
            IMaterialDesignInitializationService materialDesignInitializationService)
        {
            _viewModelContainer = viewModelContainer;
            _viewModelMappingService = viewModelMappingService;
            _materialDesignInitializationService = materialDesignInitializationService;
        }

        public async Task StartUpAsync(Assembly rootAssembly, ApplicationConfiguration appConfig)
        {
            _materialDesignInitializationService.Initialize();
            _viewModelMappingService.Initialize(rootAssembly);
            await StartAppAsync(appConfig);
        }

        private async Task StartAppAsync(ApplicationConfiguration appConfig)
        {
            await _viewModelContainer.InitializeAsync();
            var viewContainer = new ViewContainer
            {
                DataContext = _viewModelContainer,
                Icon = appConfig.Icon,
                Title = appConfig.ApplicationTitle
            };

            viewContainer.ShowDialog();
        }
    }
}