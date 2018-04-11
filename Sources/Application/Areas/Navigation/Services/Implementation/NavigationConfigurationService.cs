using System;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors.Shapings;

namespace Mmu.Mlh.WpfExtensions.Areas.Navigation.Services.Implementation
{
    public class NavigationConfigurationService : INavigationConfigurationService
    {
        public Action<INavigatableViewModel> NavigationCallback { get; private set; }

        public void Initialize(Action<INavigatableViewModel> navigationCallback)
        {
            NavigationCallback = navigationCallback;
        }
    }
}