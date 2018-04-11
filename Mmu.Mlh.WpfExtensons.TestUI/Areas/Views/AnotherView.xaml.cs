using System.Windows.Controls;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;
using Mmu.Mlh.WpfExtensions.TestUI.Areas.ViewModels;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.Views
{
    /// <summary>
    ///     Interaction logic for AnotherView.xaml
    /// </summary>
    public partial class AnotherView : UserControl, IViewMap<AnotherViewModel>
    {
        public AnotherView()
        {
            InitializeComponent();
        }
    }
}