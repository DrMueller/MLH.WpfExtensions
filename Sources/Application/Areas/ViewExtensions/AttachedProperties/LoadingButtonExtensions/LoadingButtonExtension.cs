using System;
using System.Windows;
using System.Windows.Controls;

namespace Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.AttachedProperties.LoadingButtonExtensions
{
    public static class LoadingButtonExtension
    {
        public static readonly DependencyProperty ShowLoadingProperty =
            DependencyProperty.RegisterAttached(
                "ShowLoading",
                typeof(bool),
                typeof(LoadingButtonExtension),
                new PropertyMetadata(false, ShowLoadingChanged));

        private static readonly DependencyPropertyKey _oldContentPropertyKey =
            DependencyProperty.RegisterAttachedReadOnly(
                "OldContent",
                typeof(object),
                typeof(LoadingButtonExtension),
                null);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Public static uses private static, so it is fine")]
        public static readonly DependencyProperty OldContentProperty =
            _oldContentPropertyKey.DependencyProperty;

        public static bool GetOldContent(DependencyObject dp)
        {
            return (bool)dp.GetValue(OldContentProperty);
        }

        public static bool GetShowLoading(DependencyObject dp)
        {
            return (bool)dp.GetValue(ShowLoadingProperty);
        }

        public static void SetShowLoading(DependencyObject dp, bool value)
        {
            dp.SetValue(ShowLoadingProperty, value);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "SA1119:StatementMustNotUseUnnecessaryParenthesis", Justification = "Actually needed")]
        private static void ShowLoadingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is ContentControl contentControl))
            {
                throw new ArgumentException($"Element {d.GetType().Name} is not a ContentControl.");
            }

            var showLoading = (bool)e.NewValue;
            if (showLoading)
            {
                var loadingImage = LoadingImageFactory.CreateLoadingImage();

                if (!Equals(contentControl.Content, loadingImage))
                {
                    d.SetValue(_oldContentPropertyKey, contentControl.Content);
                }

                contentControl.Content = loadingImage;
            }
            else
            {
                var oldContent = d.GetValue(OldContentProperty);
                contentControl.Content = oldContent;
            }
        }
    }
}