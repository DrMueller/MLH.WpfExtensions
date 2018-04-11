namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models
{
    public interface IViewModelCommandsContainer<in TViewModel>
        where TViewModel : ViewModelBase
    {
        void Initialize(TViewModel context);
    }
}