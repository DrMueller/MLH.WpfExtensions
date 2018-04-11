using System;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.Navigation.Services
{
    public interface INavigationConfigurationService
    {
        Action<IViewModel> NavigationCallback { get; }

        void Initialize(Action<IViewModel> navigationCallback);
    }
}