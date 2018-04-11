using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.WpfExtensions.Areas.Navigation.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.Navigation.Services
{
    public interface IMainNavigationEntryFactory
    {
        Task<IReadOnlyCollection<MainNavigationEntry>> CreateOrderedEntriesAsync();
    }
}