using System.Threading.Tasks;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Services;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.ViewHierarchies.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainNavigationViewModel, IViewModelWithHeading, IInitializableViewModel
    {
        private readonly IViewModelFactory _viewModelFactory;
        public string HeadingText { get; } = "Hierarchical Views";
        public Level1Sub1ViewModel Level1Sub1ViewModel { get; private set; }
        public Level1Sub2ViewModel Level1Sub2ViewModel { get; private set; }
        public string NavigationDescription { get; } = "Hierarchy";
        public int NavigationSequence { get; } = 4;

        public MainViewModel(IViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public async Task InitializeAsync()
        {
            Level1Sub1ViewModel = await _viewModelFactory.CreateAsync<Level1Sub1ViewModel>();
            Level1Sub2ViewModel = await _viewModelFactory.CreateAsync<Level1Sub2ViewModel>();
        }
    }
}