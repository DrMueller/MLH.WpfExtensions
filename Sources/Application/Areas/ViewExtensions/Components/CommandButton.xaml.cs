using System.Windows;
using System.Windows.Controls;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;

namespace Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Components
{
    public partial class CommandButton : UserControl
    {
        public static readonly DependencyProperty ViewModelCommandProperty =
            DependencyProperty.RegisterAttached(
                "ViewModelCommand",
                typeof(ViewModelCommand),
                typeof(CommandButton),
                new PropertyMetadata(null, null));

        public CommandButton()
        {
            InitializeComponent();
        }

        public ViewModelCommand ViewModelCommand
        {
            get => (ViewModelCommand)GetValue(ViewModelCommandProperty);
            set => SetValue(ViewModelCommandProperty, value);
        }
    }
}