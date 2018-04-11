using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors.Shapings;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Services;

namespace Mmu.Mlh.WpfExtensions.Areas.Navigation.Services.Implementation
{
    public class NavigationService : INavigationService
    {
        private readonly IViewModelFactory _containerViewModelBaseFactory;
        private readonly INavigationConfigurationService _navigationConfigurationService;

        public NavigationService(INavigationConfigurationService navigationConfigurationService, IViewModelFactory containerViewModelBaseFactory)
        {
            _navigationConfigurationService = navigationConfigurationService;
            _containerViewModelBaseFactory = containerViewModelBaseFactory;
        }

        public void NavigateTo<T>()
            where T : INavigatableViewModel
        {
            var target = _containerViewModelBaseFactory.Create<T>();
            NavigateTo(target);
        }

        public void NavigateTo(INavigatableViewModel target)
        {
            _navigationConfigurationService.NavigationCallback.Invoke(target);
        }
    }
}