using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Appearance.Models;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Appearance.Services;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Views;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Mlh.WpfExtensions.Areas.Navigation.Services;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.ViewModels
{
    public sealed class ViewModelContainer : INotifyPropertyChanged
    {
        private readonly IAppearanceService _appearanceService;
        private readonly IMainNavigationInitializingService _mainNavigationInitializer;
        private IViewModel _currentContent;
        private string _informationText;
        private bool _isMainNavigationPaneOpen;

        public ViewModelContainer(
            INavigationConfigurationService navigationConfigurationService,
            IMainNavigationInitializingService mainNavigationInitializer,
            IAppearanceService appearanceService)
        {
            _mainNavigationInitializer = mainNavigationInitializer;
            _appearanceService = appearanceService;
            navigationConfigurationService.Initialize(NavigateToViewModelCallback);
            _mainNavigationInitializer.NavigateToMainEntryPoint();
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

                // TODO: Intiialziable
                // _currentContent.OnInit();
                OnPropertyChanged();
            }
        }

        public string InformationText
        {
            get => _informationText;
            private set
            {
                if (_informationText == value)
                {
                    return;
                }

                _informationText = value;
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

        public IEnumerable<ViewModelCommand> MainNavigationEntries => _mainNavigationInitializer.GetOrderedMainNavigationEntries();

        public AppearanceTheme SelectedAppearanceTheme
        {
            get => _appearanceService.AppearanceTheme;
            set => _appearanceService.AppearanceTheme = value;
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