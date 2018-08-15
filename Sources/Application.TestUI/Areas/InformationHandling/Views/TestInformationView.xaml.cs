using System.Windows.Controls;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;
using Mmu.Mlh.WpfExtensions.TestUI.Areas.InformationHandling.ViewModels;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.InformationHandling.Views
{
    /// <summary>
    ///     Interaction logic for TestInformationView.xaml
    /// </summary>
    public partial class TestInformationView : UserControl, IViewMap<TestInformationViewModel>
    {
        public TestInformationView()
        {
            InitializeComponent();
        }
    }
}