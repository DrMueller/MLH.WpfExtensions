namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors.Shapings
{
    public interface IMainNavigationViewModel : IViewModelWithBehaviorBase
    {
        string NavigationDescription { get; }
        int NavigationSequence { get; }
    }
}