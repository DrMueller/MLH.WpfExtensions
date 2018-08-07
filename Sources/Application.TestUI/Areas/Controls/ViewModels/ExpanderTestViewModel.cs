using System.Windows.Input;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.Controls.ViewModels
{
    public class ExpanderTestViewModel : ViewModelBase, IMainNavigationViewModel, IViewModelWithHeading
    {
        private bool _isExpanderExpanded;
        public string HeadingText { get; } = "Expander Test";

        public bool IsExpanderExpanded
        {
            get => _isExpanderExpanded;
            set
            {
                _isExpanderExpanded = value;
                OnPropertyChanged();
            }
        }

        public string NavigationDescription { get; } = "Expander";
        public int NavigationSequence { get; } = 3;

        public ICommand ToggleCommand
            => new RelayCommand(
                () =>
                {
                    IsExpanderExpanded = !IsExpanderExpanded;
                });
    }
}