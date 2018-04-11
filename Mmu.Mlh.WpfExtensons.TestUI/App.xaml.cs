using System.Windows;
using Mmu.Mlh.WpfExtensions.Areas.Initialization;

namespace Mmu.Mlh.WpfExtensions.TestUI
{
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            var thisAssembly = typeof(App).Assembly;
            await BootstrapService.StartUpAsync(thisAssembly);
        }
    }
}