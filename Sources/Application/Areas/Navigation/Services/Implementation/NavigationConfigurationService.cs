using System;
using System.Diagnostics.CodeAnalysis;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.Navigation.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StrctureMap")]
    internal class NavigationConfigurationService : INavigationConfigurationService
    {
        public Action<IViewModel> NavigationCallback { get; private set; }

        public void Initialize(Action<IViewModel> navigationCallback)
        {
            NavigationCallback = navigationCallback;
        }
    }
}