using System;
using System.Windows;
using System.Windows.Controls;

namespace Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.AttachedProperties.LoadingButtonExtensions
{
    internal static class LoadingImageFactory
    {
        private static Lazy<Image> _lazyLoadingImageTemplate = new Lazy<Image>(CreateNewLoadingImage);

        internal static Image CreateLoadingImage()
        {
            return _lazyLoadingImageTemplate.Value;
        }

        private static Image CreateNewLoadingImage()
        {
            var dictionary = new ResourceDictionary
            {
                Source = new Uri(
                    "/Mmu.Mlh.WpfExtensions;component/Areas/ViewExtensions/AttachedProperties/LoadingButtonExtensions/LoadingButtonDict.xaml",
                    UriKind.RelativeOrAbsolute)
            };

            var loadingTemplate = (Image)dictionary["LoadingImage"];
            return loadingTemplate;
        }
    }
}