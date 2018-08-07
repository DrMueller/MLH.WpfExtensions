using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.Controls.ViewModels
{
    public class ButtonTestsViewModel : ViewModelBase, IMainNavigationViewModel, IViewModelWithHeading
    {
        private bool _showLoading;

        public ICommand DoLoadCommand
            => new RelayCommand(
                async () =>
                {
                    ShowLoading = true;
                    await Task.Run(
                        () =>
                        {
                            Thread.Sleep(5000);
                        });

                    ShowLoading = false;
                });

        public string HeadingText { get; } = "Button Tests";
        public string NavigationDescription { get; } = "Buttons";
        public int NavigationSequence { get; } = 2;

        public bool ShowLoading
        {
            get => _showLoading;
            set
            {
                _showLoading = value;
                OnPropertyChanged();
            }
        }
    }
}