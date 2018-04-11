using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors.Shapings;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.ViewModels
{
    public class AnotherViewModel : ViewModelBase, IMainNavigationViewModel
    {
        public string NavigationDescription { get; } = "Anotha";
        public int NavigationSequence { get; } = 2;
    }
}