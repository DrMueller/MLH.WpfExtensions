using System.Windows.Input;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands
{
    public class ViewModelCommand
    {
        public ViewModelCommand(string description, ICommand command)
        {
            Description = description;
            Command = command;
        }

        public ICommand Command { get; }
        public string Description { get; }
    }
}