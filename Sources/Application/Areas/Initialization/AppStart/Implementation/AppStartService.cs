using System.Reflection;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.MaterialDesign;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.ViewModelMapping.Services;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Views;

namespace Mmu.Mlh.WpfExtensions.Areas.Initialization.AppStart.Implementation
{
    internal class AppStartService : IAppStartService
    {
        private readonly IMaterialDesignInitializationService _materialDesignInitializationService;
        private readonly ViewContainer _viewContainer;
        private readonly IViewModelMappingService _viewModelMappingService;

        public AppStartService(
            ViewContainer viewContainer,
            IViewModelMappingService viewModelMappingService,
            IMaterialDesignInitializationService materialDesignInitializationService)
        {
            _viewContainer = viewContainer;
            _viewModelMappingService = viewModelMappingService;
            _materialDesignInitializationService = materialDesignInitializationService;
        }

        public void StartUp(Assembly rootAssembly)
        {
            _materialDesignInitializationService.Initialize();
            _viewModelMappingService.Initialize(rootAssembly);

            _viewContainer.ShowDialog();
        }
    }
}