using System.Collections.Generic;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.Navigation.Services
{
    public interface IMainNavigationInitializingService
    {
        IReadOnlyCollection<ViewModelCommand> GetOrderedMainNavigationEntries();

        void NavigateToMainEntryPoint();
    }
}