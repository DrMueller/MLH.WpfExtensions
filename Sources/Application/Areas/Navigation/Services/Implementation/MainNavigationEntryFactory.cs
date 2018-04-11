using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors.Shapings;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Mlh.WpfExtensions.Areas.Navigation.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.Navigation.Services.Implementation
{
    internal class MainNavigationEntryFactory : IMainNavigationEntryFactory
    {
        private readonly INavigationService _navigationService;
        private readonly IViewModelFactory _viewModelFactory;

        public MainNavigationEntryFactory(
            INavigationService navigationService,
            IViewModelFactory viewModelFactory)
        {
            _navigationService = navigationService;
            _viewModelFactory = viewModelFactory;
        }

        public async Task<IReadOnlyCollection<MainNavigationEntry>> CreateOrderedEntriesAsync()
        {
            var navigatableViewModels = await _viewModelFactory
                .CreateAllWithBehaviorAsync<IMainNavigationViewModel>();

            var result = navigatableViewModels
                .OrderBy(f => f.NavigationSequence)
                .Select(CreateNavigationEntry)
                .ToList();

            return result;
        }

        private MainNavigationEntry CreateNavigationEntry(IMainNavigationViewModel viewModel)
        {
            var navigationCommand = new RelayCommand(
                () =>
                {
                    _navigationService.NavigateToAsync(viewModel);
                });

            return new MainNavigationEntry(navigationCommand, viewModel.NavigationDescription);
        }
    }
}