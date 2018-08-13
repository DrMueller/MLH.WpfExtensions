namespace Mmu.Mlh.WpfExtensions.Areas.InformationHandling.ViewData
{
    public class InformationEntryViewData
    {
        public InformationEntryViewData(string message, bool showBusyIndicator)
        {
            Message = message;
            ShowBusyIndicator = showBusyIndicator;
        }

        public static string BusyIndicatorSource => "/Mmu.Mlh.WpfExtensions;component/Infrastructure/Assets/FA_Cog_Green.png";
        public string Message { get; }
        public bool ShowBusyIndicator { get; }
    }
}