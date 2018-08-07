using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;
using Mmu.Mlh.WpfExtensions.TestUI.Areas.Controls.ViewModels;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.Controls.Views
{
    /// <summary>
    /// Interaction logic for ExpanderTestView.xaml
    /// </summary>
    public partial class ExpanderTestView : UserControl, IViewMap<ExpanderTestViewModel>
    {
        public ExpanderTestView()
        {
            InitializeComponent();
        }
    }
}
