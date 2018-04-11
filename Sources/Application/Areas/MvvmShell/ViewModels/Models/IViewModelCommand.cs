using System.Windows.Input;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models
{
    public interface IViewModelCommand
    {
        ICommand Command { get; }
        string Description { get; }
    }
}