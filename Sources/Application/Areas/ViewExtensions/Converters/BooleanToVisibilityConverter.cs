using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Converters
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by WPF")]
    internal class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = (Visibility)value;
            return visibility == Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var b = (bool)value;
            return b ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}