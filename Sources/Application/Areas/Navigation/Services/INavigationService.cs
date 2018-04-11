using System.Threading.Tasks;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.Navigation.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync<T>()
            where T : IViewModel;

        Task NavigateToAsync(IViewModel target);
    }
}