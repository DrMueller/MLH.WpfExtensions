using System.Windows.Controls;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;
using Mmu.Mlh.WpfExtensions.TestUI.Areas.ViewModels;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.Views
{
    /// <summary>
    ///     Interaction logic for NoMainNavigationView.xaml
    /// </summary>
    public partial class NoMainNavigationView : UserControl, IViewMap<NoMainNavigationViewModel>
    {
        public NoMainNavigationView()
        {
            InitializeComponent();
        }
    }
}