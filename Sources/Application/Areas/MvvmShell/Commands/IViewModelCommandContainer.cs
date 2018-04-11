using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands
{
    public interface IViewModelCommandContainer<in TViewModel>
        where TViewModel : ViewModelBase
    {
        void Initialize(TViewModel context);
    }
}