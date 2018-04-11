using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors.Shapings;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Services;

namespace Mmu.Mlh.WpfExtensions.Areas.Navigation.Services.Implementation
{
    public class MainNavigationInitializingService : IMainNavigationInitializingService
    {
        private readonly INavigationService _navigationService;
        private readonly IViewModelFactory _viewModelFactory;
        private IReadOnlyCollection<ViewModelCommand> _navigationViewModelCommands;

        public MainNavigationInitializingService(
            INavigationService navigationService,
            IViewModelFactory viewModelFactory)
        {
            _navigationService = navigationService;
            _viewModelFactory = viewModelFactory;
        }

        public IReadOnlyCollection<ViewModelCommand> GetOrderedMainNavigationEntries()
        {
            AssureNavigationIsInitialized();
            return _navigationViewModelCommands;
        }

        public void NavigateToMainEntryPoint()
        {
            AssureNavigationIsInitialized();
            var mainEntry = _navigationViewModelCommands.FirstOrDefault();
            mainEntry?.Command.Execute(null);
        }

        private void AssureNavigationIsInitialized()
        {
            if (_navigationViewModelCommands == null)
            {
                _navigationViewModelCommands = CreateOrderedNavigationViewModels();
            }
        }

        private IReadOnlyCollection<ViewModelCommand> CreateOrderedNavigationViewModels()
        {
            var viewModelsDict = new Dictionary<int, ViewModelCommand>();
            var navigatableViewModels = _viewModelFactory.CreateAllWithBehavior<INavigatableViewModel>();

            foreach (var navigatableViewModel in navigatableViewModels)
            {
                var vmc = new ViewModelCommand(
                    navigatableViewModel.NavigationDescription,
                    new RelayCommand(
                        () =>
                        {
                            _navigationService.NavigateTo(navigatableViewModel);
                        }));

                viewModelsDict.Add(navigatableViewModel.NavigationSequence, vmc);
            }

            var result = viewModelsDict.OrderBy(f => f.Key).Select(f => f.Value).ToList();
            return result.AsReadOnly();
        }
    }
}