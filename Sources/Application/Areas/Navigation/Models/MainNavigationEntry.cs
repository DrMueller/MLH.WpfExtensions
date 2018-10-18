using System.Windows.Input;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WpfExtensions.Areas.Navigation.Models
{
    public class MainNavigationEntry
    {
        public ICommand NavigationCommand { get; }
        public string NavigationDescription { get; }

        public MainNavigationEntry(ICommand navigationCommand, string navigationDescription)
        {
            Guard.ObjectNotNull(() => navigationCommand);
            Guard.StringNotNullOrEmpty(() => navigationDescription);

            NavigationCommand = navigationCommand;
            NavigationDescription = navigationDescription;
        }
    }
}