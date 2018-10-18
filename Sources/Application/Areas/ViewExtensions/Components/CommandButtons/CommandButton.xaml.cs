using System.Windows;
using System.Windows.Controls;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;

namespace Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Components.CommandButtons
{
    public partial class CommandButton : UserControl
    {
        public static readonly DependencyProperty ViewModelCommandProperty =
            DependencyProperty.Register(
                nameof(ViewModelCommand),
                typeof(ViewModelCommand),
                typeof(CommandButton),
                new PropertyMetadata(null, null));

        public ViewModelCommand ViewModelCommand
        {
            get => (ViewModelCommand)GetValue(ViewModelCommandProperty);
            set => SetValue(ViewModelCommandProperty, value);
        }

        public CommandButton()
        {
            InitializeComponent();
        }
    }
}