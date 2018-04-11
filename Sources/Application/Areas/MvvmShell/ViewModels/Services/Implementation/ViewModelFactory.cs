using System;
using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors.Shapings;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Services.Implementation
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly IViewModel[] _viewModels;

        public ViewModelFactory(IViewModel[] viewModels)
        {
            _viewModels = viewModels;
        }

        public T Create<T>() where T : IViewModel => (T)Create(typeof(T));

        public IViewModel Create(Type viewModelType)
        {
            var viewModelBaseType = typeof(IViewModel);
            if (!viewModelBaseType.IsAssignableFrom(viewModelType))
            {
                throw new ArgumentException($"{viewModelType.Name} is not assignable from IViewModel.");
            }

            var result = _viewModels.FirstOrDefault(f => f.GetType() == viewModelBaseType);
            return result;
        }

        public IReadOnlyCollection<TBehavior> CreateAllWithBehavior<TBehavior>() where TBehavior : IViewModelWithBehaviorBase
        {
            var behaviorType = typeof(TBehavior);
            var result = _viewModels.Where(f => behaviorType.IsInstanceOfType(f)).Cast<TBehavior>().ToList();
            return result;
        }
    }
}