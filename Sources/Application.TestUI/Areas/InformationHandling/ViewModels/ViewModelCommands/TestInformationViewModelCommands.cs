using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Services;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Components.CommandBars.ViewData;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.InformationHandling.ViewModels.ViewModelCommands
{
    public class TestInformationViewModelCommands : IViewModelCommandContainer<TestInformationViewModel>
    {
        private readonly IInformationPublishingService _informationPublishingService;
        public CommandsViewData Commands { get; private set; }

        public TestInformationViewModelCommands(IInformationPublishingService informationPublishingService)
        {
            _informationPublishingService = informationPublishingService;
        }

        private IViewModelCommand After5Seconds
        {
            get
            {
                return new ViewModelCommand(
                    "After 5 seconds",
                    new RelayCommand(
                        async () =>
                        {
                            _informationPublishingService.Publish(InformationEntry.CreateInfo("Test1", true, 5));
                            await Task.Delay(10000);
                            _informationPublishingService.Publish(InformationEntry.CreateInfo("Test2", false, 10));
                            _informationPublishingService.Publish(InformationEntry.CreateInfo("Test3", true, 3));
                        }));
            }
        }

        public Task InitializeAsync(TestInformationViewModel context)
        {
            Commands = new CommandsViewData(After5Seconds);
            return Task.CompletedTask;
        }
    }
}