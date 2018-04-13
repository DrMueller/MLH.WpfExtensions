using System.Windows.Controls;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;
using Mmu.Mlh.WpfExtensions.TestUI.Areas.ValidationTests.ViewModels;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.ValidationTests.View
{
    /// <summary>
    ///     Interaction logic for SimpleValidationView.xaml
    /// </summary>
    public partial class SimpleValidationView : UserControl, IViewMap<SimpleValidationViewModel>
    {
        public SimpleValidationView()
        {
            InitializeComponent();
        }
    }
}