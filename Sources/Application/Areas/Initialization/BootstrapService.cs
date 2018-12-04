using System;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.AppStart;

namespace Mmu.Mlh.WpfExtensions.Areas.Initialization
{
    public static class BootstrapService
    {
        public static async Task StartUpAsync(
            ContainerConfiguration containerConfig,
            ApplicationConfiguration appConfig,
            Maybe<Action> appInitializedCallbackMaybe)
        {
            ContainerInitializationService.CreateInitializedContainer(containerConfig);
            var appStartService = ServiceLocatorSingleton.Instance.GetService<IAppStartService>();
            await appStartService.StartUpAsync(containerConfig.RootAssembly, appConfig, appInitializedCallbackMaybe);
        }
    }
}