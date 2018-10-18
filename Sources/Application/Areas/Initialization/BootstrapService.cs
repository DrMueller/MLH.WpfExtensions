using System;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.AppStart;

namespace Mmu.Mlh.WpfExtensions.Areas.Initialization
{
    public static class BootstrapService
    {
        public static async Task StartUpAsync(
            AssemblyParameters containerInitializationParameters,
            ApplicationConfiguration appConfig,
            Maybe<Action> appInitializedCallbackMaybe)
        {
            ContainerInitializationService.CreateInitializedContainer(containerInitializationParameters);
            var appStartService = ProvisioningServiceSingleton.Instance.GetService<IAppStartService>();
            await appStartService.StartUpAsync(containerInitializationParameters.RootAssembly, appConfig, appInitializedCallbackMaybe);
        }
    }
}