using System.Windows;

namespace Mmu.Mlh.WpfExtensions.TestUI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var thisAssembly = typeof(App).Assembly;
            WpfExtensions.Areas.Initialization.BootstrapService.StartUp(thisAssembly);
        }
    }
}