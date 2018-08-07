using System;
using Mmu.Mlh.WpfExtensions.Areas.InformationHandling.ViewData;

namespace Mmu.Mlh.WpfExtensions.Areas.InformationHandling.Services
{
    public interface IInformationSubscriptionViewService
    {
        void RegisterSubscriber(Action<InformationEntryViewData> subscriber);
    }
}