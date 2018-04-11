using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors.Shapings;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.ViewModels
{
    public class HomeViewModel : ViewModelBase, IMainNavigationViewModel, IViewModelWithHeading
    {
        public string HeadingText { get; } = "Hello Home";
        public string NavigationDescription { get; } = "Home";
        public int NavigationSequence { get; } = 1;

        // TODO View modelcommands

    }
}