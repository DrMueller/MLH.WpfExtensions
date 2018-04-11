using System;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.Navigation.Services.Implementation
{
    internal class NavigationConfigurationService : INavigationConfigurationService
    {
        public Action<IViewModel> NavigationCallback { get; private set; }

        public void Initialize(Action<IViewModel> navigationCallback)
        {
            NavigationCallback = navigationCallback;
        }
    }
}