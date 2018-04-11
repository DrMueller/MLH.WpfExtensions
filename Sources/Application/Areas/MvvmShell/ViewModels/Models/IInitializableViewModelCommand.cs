namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models
{
    public interface IInitializableViewModelCommand<in TViewModel> : IViewModelCommand
        where TViewModel : ViewModelBase
    {
        void Initialize(TViewModel context);
    }
}