using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Mmu.Mlh.WpfExtensions.Areas.Initialization;

namespace Mmu.Mlh.WpfExtensions.TestUI
{
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            var thisAssembly = typeof(App).Assembly;
            var appIcon = TestUI.Properties.Resources.M;

            var appConfig = ApplicationConfiguration.CreateFromIcon("Hello Test", appIcon);
            await BootstrapService.StartUpAsync(thisAssembly, appConfig);
        }
    }
}