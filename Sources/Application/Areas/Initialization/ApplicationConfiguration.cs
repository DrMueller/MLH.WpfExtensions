using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WpfExtensions.Areas.Initialization
{
    public class ApplicationConfiguration
    {
        private ApplicationConfiguration(string applicationTitle, ImageSource icon)
        {
            Guard.StringNotNullOrEmpty(() => applicationTitle);
            Guard.ObjectNotNull(() => icon);
            ApplicationTitle = applicationTitle;
            Icon = icon;
        }

        public string ApplicationTitle { get; }
        public ImageSource Icon { get; }

        public static ApplicationConfiguration CreateFromIcon(string applicationTitle, Icon icon)
        {
            ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            return new ApplicationConfiguration(applicationTitle, imageSource);
        }
    }
}