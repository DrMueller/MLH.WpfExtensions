using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.AttachedProperties
{
    public static class DataGridDoubleClickCommandBinding
    {
        public static readonly DependencyProperty DataGridDoubleClickProperty = DependencyProperty.RegisterAttached("DataGridDoubleClickCommand", typeof(ICommand), typeof(DataGridDoubleClickCommandBinding), new PropertyMetadata(AttachOrRemoveDataGridDoubleClickEvent));

        [SuppressMessage("Microsoft.Usage", "SA1119:StatementMustNotUseUnnecessaryParenthesis", Justification = "Actually needed")]
        public static void AttachOrRemoveDataGridDoubleClickEvent(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (!(dependencyObject is DataGrid dataGrid))
            {
                return;
            }


            if (args.OldValue == null && args.NewValue != null)
            {
                dataGrid.MouseDoubleClick += ExecuteDataGridDoubleClick;
            }
            else if (args.OldValue != null && args.NewValue == null)
            {
                dataGrid.MouseDoubleClick -= ExecuteDataGridDoubleClick;
            }
        }

        public static ICommand GetDataGridDoubleClickCommand(DependencyObject dependencyObject)
        {
            return (ICommand)dependencyObject.GetValue(DataGridDoubleClickProperty);
        }

        public static void SetDataGridDoubleClickCommand(DependencyObject dependencyObject, ICommand value)
        {
            dependencyObject.SetValue(DataGridDoubleClickProperty, value);
        }

        private static void ExecuteDataGridDoubleClick(object sender, MouseButtonEventArgs args)
        {
            var dependencyObject = sender as DependencyObject;
            var cmd = (ICommand)dependencyObject?.GetValue(DataGridDoubleClickProperty);
            if (cmd == null)
            {
                return;
            }

            if (cmd.CanExecute(dependencyObject))
            {
                cmd.Execute(dependencyObject);
            }
        }
    }
}