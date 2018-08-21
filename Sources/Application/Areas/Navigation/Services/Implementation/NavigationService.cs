using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Services;

namespace Mmu.Mlh.WpfExtensions.Areas.Navigation.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StructureMap")]
    internal class NavigationService : INavigationService
    {
        private readonly IViewModelFactory _containerViewModelBaseFactory;

        private readonly INavigationConfigurationService _navigationConfigurationService;

        public NavigationService(INavigationConfigurationService navigationConfigurationService, IViewModelFactory containerViewModelBaseFactory)
        {
            _navigationConfigurationService = navigationConfigurationService;
            _containerViewModelBaseFactory = containerViewModelBaseFactory;
        }

        public async Task NavigateToAsync<T>()
            where T : IViewModel
        {
            var target = await _containerViewModelBaseFactory.CreateAsync<T>();
            await NavigateToAsync(target);
        }

        public Task NavigateToAsync(IViewModel target)
        {
            _navigationConfigurationService.NavigationCallback.Invoke(target);
            return Task.CompletedTask;
        }
    }
}