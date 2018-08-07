using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Services;
using Mmu.Mlh.WpfExtensions.Areas.InformationHandling.ViewData;

namespace Mmu.Mlh.WpfExtensions.Areas.InformationHandling.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StrctureMap")]
    internal class InformationSubscriptionViewService : IInformationSubscriptionViewService
    {
        private readonly List<Action<InformationEntryViewData>> _subscribers = new List<Action<InformationEntryViewData>>();

        public InformationSubscriptionViewService(IInformationSubscriptionService informatonSusbcriptionService)
        {
            informatonSusbcriptionService.RegisterSubscriber(InformationReceived);
        }

        public void RegisterSubscriber(Action<InformationEntryViewData> subscriber)
        {
            _subscribers.Add(subscriber);
        }

        private void InformationReceived(InformationEntry obj)
        {
            var viewData = new InformationEntryViewData(obj.Message, obj.IsBusy);
            _subscribers.ForEach(subs => subs(viewData));
        }
    }
}