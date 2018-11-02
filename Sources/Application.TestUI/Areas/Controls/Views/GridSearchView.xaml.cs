using System.Windows.Controls;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;
using Mmu.Mlh.WpfExtensions.TestUI.Areas.Controls.ViewModels;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.Controls.Views
{
    /// <summary>
    ///     Interaction logic for GridSearchView.xaml
    /// </summary>
    public partial class GridSearchView : UserControl, IViewMap<GridSearchViewModel>
    {
        public GridSearchView()
        {
            InitializeComponent();
        }
    }
}