using System.Windows.Input;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands
{
    public interface IViewModelCommand
    {
        ICommand Command { get; }
        string Description { get; }
    }
}