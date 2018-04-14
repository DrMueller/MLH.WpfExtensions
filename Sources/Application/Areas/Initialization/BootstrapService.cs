using System.Reflection;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.AppStart;

namespace Mmu.Mlh.WpfExtensions.Areas.Initialization
{
    public static class BootstrapService
    {
        public static async Task StartUpAsync(Assembly rootAssembly)
        {
            var appStartService = ProvisioningServiceSingleton.Instance.GetService<IAppStartService>();
            await appStartService.StartUpAsync(rootAssembly);
        }
    }
}