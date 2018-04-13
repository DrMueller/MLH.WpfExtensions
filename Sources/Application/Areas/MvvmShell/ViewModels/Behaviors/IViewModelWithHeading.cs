namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors
{
    public interface IViewModelWithHeading : IViewModelWithBehaviorBase
    {
        string HeadingText { get; }
    }
}