using System.Threading.Tasks;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfExtensions.TestUI.Areas.InformationHandling.ViewModels.ViewModelCommands;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.InformationHandling.ViewModels
{
    public class TestInformationViewModel : ViewModelBase, IMainNavigationViewModel, IViewModelWithHeading, IInitializableViewModel
    {
        private readonly TestInformationViewModelCommands _commandsContainer;
        public CommandsViewData Commands => _commandsContainer.Commands;
        public string HeadingText { get; } = "Information testing";
        public string NavigationDescription { get; } = "Information";
        public int NavigationSequence { get; } = 2;

        public TestInformationViewModel(TestInformationViewModelCommands commandsContainer)
        {
            _commandsContainer = commandsContainer;
        }

        public async Task InitializeAsync()
        {
            await _commandsContainer.InitializeAsync(this);
        }
    }
}