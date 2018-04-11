using System;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors.Shapings;

namespace Mmu.Mlh.WpfExtensions.Areas.Navigation.Services
{
    public interface INavigationConfigurationService
    {
        Action<INavigatableViewModel> NavigationCallback { get; }

        void Initialize(Action<INavigatableViewModel> navigationCallback);
    }
}