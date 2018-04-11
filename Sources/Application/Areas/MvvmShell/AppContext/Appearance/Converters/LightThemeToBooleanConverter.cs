﻿using System;
using System.Globalization;
using System.Windows.Data;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Appearance.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Appearance.Converters
{
    internal class LightThemeToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var appearanceTheme = (AppearanceTheme)value;
            return appearanceTheme == AppearanceTheme.Light;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var appearanceThemeIsLight = (bool)value;
            return appearanceThemeIsLight ? AppearanceTheme.Light : AppearanceTheme.Dark;
        }
    }
}