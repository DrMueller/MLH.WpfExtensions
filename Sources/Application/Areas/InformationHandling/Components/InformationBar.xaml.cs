using System.Windows;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Models;
using Mmu.Mlh.WpfExtensions.Areas.InformationHandling.ViewData;

namespace Mmu.Mlh.WpfExtensions.Areas.InformationHandling.Components
{
    public partial class InformationBar
    {
        public static readonly DependencyProperty InformationEntryProperty =
            DependencyProperty.Register(
                nameof(InformationEntry),
                typeof(InformationEntryViewData),
                typeof(InformationBar));

        public InformationBar()
        {
            InitializeComponent();
        }

        public InformationEntryViewData InformationEntry
        {
            get => (InformationEntryViewData)GetValue(InformationEntryProperty);
            set => SetValue(InformationEntryProperty, value);
        }
    }
}