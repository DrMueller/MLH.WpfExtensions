using System.Windows.Controls;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;
using Mmu.Mlh.WpfExtensions.TestUI.Areas.ViewHierarchies.ViewModels;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.ViewHierarchies.Views
{
    /// <summary>
    ///     Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl, IViewMap<MainViewModel>
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}