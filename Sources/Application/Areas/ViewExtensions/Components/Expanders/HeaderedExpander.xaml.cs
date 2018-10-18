using System.Windows;

namespace Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Components.Expanders
{
    public partial class HeaderedExpander
    {
        public static readonly DependencyProperty BodyContentProperty =
            DependencyProperty.Register(
                nameof(BodyContent),
                typeof(object),
                typeof(HeaderedExpander),
                new PropertyMetadata(null, null));
        public static readonly DependencyProperty HeaderContentProperty =
            DependencyProperty.Register(
                nameof(HeaderContent),
                typeof(object),
                typeof(HeaderedExpander),
                new PropertyMetadata(null, null));
        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register(
                nameof(IsExpanded),
                typeof(bool),
                typeof(HeaderedExpander),
                new PropertyMetadata(true, null));

        public object BodyContent
        {
            get => GetValue(BodyContentProperty);
            set => SetValue(BodyContentProperty, value);
        }

        public object HeaderContent
        {
            get => GetValue(HeaderContentProperty);
            set => SetValue(HeaderContentProperty, value);
        }

        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }

        public HeaderedExpander()
        {
            InitializeComponent();
        }
    }
}