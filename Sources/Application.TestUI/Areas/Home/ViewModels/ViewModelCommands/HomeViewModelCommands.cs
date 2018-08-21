using System.Threading.Tasks;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.Navigation.Services;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.Home.ViewModels.ViewModelCommands
{
    public class HomeViewModelCommands : IViewModelCommandContainer<HomeViewModel>
    {
        private readonly INavigationService _navigationService;

        public HomeViewModelCommands(INavigationService navigationService) => _navigationService = navigationService;

        public ViewModelCommand NavigateToNoMainNavigation { get; private set; }

        public Task InitializeAsync(HomeViewModel context)
        {
            return Task.Run(
                () =>
                {
                    NavigateToNoMainNavigation = new ViewModelCommand(
                        "Navigate away!",
                        new RelayCommand(
                            () =>
                            {
                                _navigationService.NavigateToAsync<NoMainNavigationViewModel>();
                            }));
                });
        }
    }
}