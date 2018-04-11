using System.Reflection;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.AppStart;

namespace Mmu.Mlh.WpfExtensions.Areas.Initialization
{
    public static class BootstrapService
    {
        public static void StartUp(Assembly rootAssembly)
        {
            ContainerInitializationService.CreateInitializedContainer(rootAssembly);

            var appStartService = ProvisioningServiceSingleton.Instance.GetService<IAppStartService>();
            appStartService.StartUp(rootAssembly);
        }
    }
}