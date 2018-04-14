﻿using System;
using System.Diagnostics.CodeAnalysis;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.MaterialDesign.Handlers;

namespace Mmu.Mlh.WpfExtensions.Areas.Initialization.MaterialDesign.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StructureMap")]
    internal class MaterialDesignInitializationService : IMaterialDesignInitializationService
    {
        private readonly IResourceDictionaryFactory _resourceDictionaryFactory;

        public MaterialDesignInitializationService(IResourceDictionaryFactory resourceDictionaryFactory)
        {
            _resourceDictionaryFactory = resourceDictionaryFactory;
        }

        public void Initialize()
        {
            AppendNewResourceDictionary("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml");
            AppendNewResourceDictionary("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml");
            AppendNewResourceDictionary("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Blue.xaml");
            AppendNewResourceDictionary("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Cyan.xaml");
        }

        private void AppendNewResourceDictionary(string sourcePath)
        {
            var resourceDictionary = _resourceDictionaryFactory.CreateEmpty();
            resourceDictionary.Source = new Uri(sourcePath);
            System.Windows.Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }
    }
}