using System.Windows.Controls;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;
using Mmu.Mlh.WpfExtensions.TestUI.Areas.ViewHierarchies.ViewModels;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.ViewHierarchies.Views
{
    /// <summary>
    ///     Interaction logic for Level1Sub1View.xaml
    /// </summary>
    public partial class Level1Sub1View : UserControl, IViewMap<Level1Sub1ViewModel>
    {
        public Level1Sub1View()
        {
            InitializeComponent();
        }
    }
}