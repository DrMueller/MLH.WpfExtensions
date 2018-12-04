using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Services.Implementation
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly IServiceLocator _serviceLocator;

        public ViewModelFactory(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public async Task<IReadOnlyCollection<TBehavior>> CreateAllWithBehaviorAsync<TBehavior>()
            where TBehavior : IViewModelWithBehaviorBase
        {
            var behaviorType = typeof(TBehavior);
            var viewModelsWithBehaviorType =
                _serviceLocator
                    .GetAllServices<IViewModel>()
                    .Where(f => behaviorType.IsInstanceOfType(f))
                    .Select(f => f.GetType())
                    .ToList();

            // We want to use the create method to hook the IInitializableViewModel properly
            var createTasks = viewModelsWithBehaviorType.Select(CreateAsync);
            var createdVieModels = await Task.WhenAll(createTasks);

            var result = createdVieModels.Cast<TBehavior>().ToList();
            return result;
        }

        public async Task<T> CreateAsync<T>()
            where T : IViewModel
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

            var result = (IViewModel)_serviceLocator.GetService(viewModelType);
            if (result is IInitializableViewModel initializable)
            {
                await initializable.InitializeAsync();
            }

            return result;
        }
    }
}