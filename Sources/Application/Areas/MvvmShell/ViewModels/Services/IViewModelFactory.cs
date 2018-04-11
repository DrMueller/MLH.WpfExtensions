using System;
using System.Collections.Generic;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors.Shapings;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Services
{
    public interface IViewModelFactory
    {
        T Create<T>()
            where T : IViewModel;

        IViewModel Create(Type viewModelType);

        IReadOnlyCollection<TBehavior> CreateAllWithBehavior<TBehavior>()
            where TBehavior : IViewModelWithBehaviorBase;
    }
}