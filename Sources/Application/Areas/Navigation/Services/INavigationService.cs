using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors.Shapings;

namespace Mmu.Mlh.WpfExtensions.Areas.Navigation.Services
{
    public interface INavigationService
    {
        void NavigateTo<T>()
            where T : INavigatableViewModel;

        void NavigateTo(INavigatableViewModel target);
    }
}