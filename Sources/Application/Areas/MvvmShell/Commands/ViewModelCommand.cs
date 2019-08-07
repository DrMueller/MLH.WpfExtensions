using System.Windows.Input;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands
{
    public class ViewModelCommand : IViewModelCommand
    {
        public ICommand Command { get; }
        public string Description { get; }

        public ViewModelCommand(string description, ICommand command)
        {
            Description = description;
            Command = command;
        }
    }
}