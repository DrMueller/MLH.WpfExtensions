using System.Threading.Tasks;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Services;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.ViewHierarchies.ViewModels
{
    public class Level1Sub1ViewModel : ViewModelBase, IInitializableViewModel
    {
        private readonly IViewModelFactory _viewModelFactory;
        public string Hello { get; } = "Hello From Level 1 Sub 1!";
        public Level2ViewModel Level2ViewModel { get; private set; }

        public Level1Sub1ViewModel(IViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public async Task InitializeAsync()
        {
            Level2ViewModel = await _viewModelFactory.CreateAsync<Level2ViewModel>();
        }
    }
}