using System.Windows;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.ViewModels;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Views
{
    public partial class ViewContainer : Window, IClosableView
    {
        public ViewContainer(ViewModelContainer viewModelContainer)
        {
            DataContext = viewModelContainer;
            InitializeComponent();
        }
    }
}