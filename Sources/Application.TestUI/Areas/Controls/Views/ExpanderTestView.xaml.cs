using System.Windows.Controls;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;
using Mmu.Mlh.WpfExtensions.TestUI.Areas.Controls.ViewModels;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.Controls.Views
{
    /// <summary>
    ///     Interaction logic for ExpanderTestView.xaml
    /// </summary>
    public partial class ExpanderTestView : UserControl, IViewMap<ExpanderTestViewModel>
    {
        public ExpanderTestView()
        {
            InitializeComponent();
        }
    }
}