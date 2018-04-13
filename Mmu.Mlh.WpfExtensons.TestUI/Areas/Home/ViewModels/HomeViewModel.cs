using System.Threading.Tasks;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Mlh.WpfExtensions.TestUI.Areas.Home.ViewModels.ViewModelCommands;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.Home.ViewModels
{
    public class HomeViewModel : ViewModelBase, IMainNavigationViewModel, IViewModelWithHeading, IInitializableViewModel
    {
        private readonly HomeViewModelCommands _viewModelCommands;

        public HomeViewModel(HomeViewModelCommands viewModelCommands)
        {
            _viewModelCommands = viewModelCommands;
        }

        public string HeadingText { get; } = "Hello Home";
        public ViewModelCommand NavigateToNoMainNavigation => _viewModelCommands.NavigateToNoMainNavigation;
        public string NavigationDescription { get; } = "Home";
        public int NavigationSequence { get; } = 1;

        public async Task InitializeAsync()
        {
            await _viewModelCommands.InitializeAsync(this);
        }
    }
}