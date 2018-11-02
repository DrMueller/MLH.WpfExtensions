using System.Windows.Controls;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;
using Mmu.Mlh.WpfExtensions.TestUI.Areas.ViewHierarchies.ViewModels;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.ViewHierarchies.Views
{
    /// <summary>
    ///     Interaction logic for Level1Sub2View.xaml
    /// </summary>
    public partial class Level1Sub2View : UserControl, IViewMap<Level1Sub2ViewModel>
    {
        public Level1Sub2View()
        {
            InitializeComponent();
        }
    }
}