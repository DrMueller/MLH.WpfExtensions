using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors.Shapings;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Services.Implementation
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly IProvisioningService _provisioningService;

        public ViewModelFactory(IProvisioningService provisioningService)
        {
            _provisioningService = provisioningService;
        }

        public Task<IReadOnlyCollection<TBehavior>> CreateAllWithBehaviorAsync<TBehavior>() where TBehavior : IViewModelWithBehaviorBase
        {
            var behaviorType = typeof(TBehavior);
            IReadOnlyCollection<TBehavior> result = 
                _provisioningService
                .GetAllServices<IViewModel>()
                .Where(f => behaviorType.IsInstanceOfType(f))
                .Cast<TBehavior>()
                .ToList();

            return Task.FromResult(result);
        }

        public async Task<T> CreateAsync<T>() where T : IViewModel
        {
            var result = (T)await CreateAsync(typeof(T));
            return result;
        }

        public async Task<IViewModel> CreateAsync(Type viewModelType)
        {
            var viewModelBaseType = typeof(IViewModel);
            if (!viewModelBaseType.IsAssignableFrom(viewModelType))
            {
                throw new ArgumentException($"{viewModelType.Name} is not assignable from IViewModel.");
            }

            var result = (IViewModel)_provisioningService.GetService(viewModelType);
            if (result is IInitializableViewModel initializable)
            {
                await initializable.InitializeAsync();
            }

            return result;
        }
    }
}