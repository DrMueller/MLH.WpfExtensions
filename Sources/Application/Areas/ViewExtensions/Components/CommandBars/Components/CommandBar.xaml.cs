using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Components.CommandBars.ViewData;

namespace Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Components.CommandBars.Components
{
    /// <summary>
    ///     Interaction logic for CommandBar.xaml
    /// </summary>
    public partial class CommandBar : UserControl
    {
        public static readonly DependencyProperty CommandsProperty =
            DependencyProperty.Register(
                nameof(Commands),
                typeof(CommandsViewData),
                typeof(CommandBar),
                new PropertyMetadata(null, null));

        public CommandBar()
        {
            InitializeComponent();
        }

        public CommandsViewData Commands
        {
            get => (CommandsViewData)GetValue(CommandsProperty);
            set => SetValue(CommandsProperty, value);
        }
    }
}