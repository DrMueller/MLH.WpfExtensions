using System.Windows.Controls;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;
using Mmu.Mlh.WpfExtensions.TestUI.Areas.Controls.ViewModels;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.Controls.Views
{
    /// <summary>
    ///     Interaction logic for ButtonTestsView2.xaml
    /// </summary>
    public partial class ButtonTestsView : UserControl, IViewMap<ButtonTestsViewModel>
    {
        public ButtonTestsView()
        {
            InitializeComponent();
        }
    }
}