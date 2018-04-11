using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors.Shapings;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Services
{
    public interface IViewModelFactory
    {
        Task<T> CreateAsync<T>()
            where T : IViewModel;

        Task<IViewModel> CreateAsync(Type viewModelType);

        Task<IReadOnlyCollection<TBehavior>> CreateAllWithBehaviorAsync<TBehavior>()
            where TBehavior : IViewModelWithBehaviorBase;
    }
}