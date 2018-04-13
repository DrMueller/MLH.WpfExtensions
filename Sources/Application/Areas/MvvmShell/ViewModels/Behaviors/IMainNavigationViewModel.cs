namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors
{
    public interface IMainNavigationViewModel : IViewModelWithBehaviorBase
    {
        string NavigationDescription { get; }
        int NavigationSequence { get; }
    }
}