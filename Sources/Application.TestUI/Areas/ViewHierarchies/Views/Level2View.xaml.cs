using System.Windows.Controls;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;
using Mmu.Mlh.WpfExtensions.TestUI.Areas.ViewHierarchies.ViewModels;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.ViewHierarchies.Views
{
    /// <summary>
    ///     Interaction logic for Level2View.xaml
    /// </summary>
    public partial class Level2View : UserControl, IViewMap<Level2ViewModel>
    {
        public Level2View()
        {
            InitializeComponent();
        }
    }
}