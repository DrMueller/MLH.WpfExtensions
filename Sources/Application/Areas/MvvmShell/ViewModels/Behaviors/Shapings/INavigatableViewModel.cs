namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors.Shapings
{
    public interface INavigatableViewModel : IViewModelWithBehaviorBase
    {
        string NavigationDescription { get; }
        int NavigationSequence { get; }
    }
}