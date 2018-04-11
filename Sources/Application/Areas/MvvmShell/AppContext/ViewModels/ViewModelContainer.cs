using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Appearance.Models;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Appearance.Services;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Views;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Mlh.WpfExtensions.Areas.Navigation.Models;
using Mmu.Mlh.WpfExtensions.Areas.Navigation.Services;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.ViewModels
{
    public sealed class ViewModelContainer : INotifyPropertyChanged
    {
        private readonly IAppearanceService _appearanceService;
        private readonly INavigationConfigurationService _navigationConfigurationService;
        private readonly IMainNavigationEntryFactory _navigationEntryFactory;
        private IViewModel _currentContent;
        private bool _isMainNavigationPaneOpen;

        public ViewModelContainer(
            INavigationConfigurationService navigationConfigurationService,
            IMainNavigationEntryFactory navigationEntryFactory,
            IAppearanceService appearanceService)
        {
            _navigationConfigurationService = navigationConfigurationService;
            _navigationEntryFactory = navigationEntryFactory;
            _appearanceService = appearanceService;
        }

        public static ParametredRelayCommand CloseCommand
        {
            get
            {
                return new ParametredRelayCommand(
                    o =>
                    {
                        var closable = (IClosableView)o;
                        closable.Close();
                    });
            }
        }

        public ICommand CloseMainNavigationPane
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {
                        IsMainNavigationPaneOpen = false;
                    });
            }
        }

        public static ViewModelCommand CloseVmc => new ViewModelCommand("Close App", CloseCommand);

        public IViewModel CurrentContent
        {
            get => _currentContent;
            private set
            {
                if (_currentContent == value)
                {
                    return;
                }

                _currentContent = value;
                OnPropertyChanged();
            }
        }

        public bool IsMainNavigationPaneOpen
        {
            get => _isMainNavigationPaneOpen;
            set
            {
                if (_isMainNavigationPaneOpen == value)
                {
                    return;
                }

                _isMainNavigationPaneOpen = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<MainNavigationEntry> NavigationEntries { get; private set; }

        public AppearanceTheme SelectedAppearanceTheme
        {
            get => _appearanceService.AppearanceTheme;
            set => _appearanceService.AppearanceTheme = value;
        }

        public async Task InitializeAsync()
        {
            _navigationConfigurationService.Initialize(NavigateToViewModelCallback);
            NavigationEntries = await _navigationEntryFactory.CreateOrderedEntriesAsync();
            NavigationEntries.FirstOrDefault()?.NavigationCommand.Execute(null);
        }

        private void NavigateToViewModelCallback(IViewModel viewModel)
        {
            CurrentContent = viewModel;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}