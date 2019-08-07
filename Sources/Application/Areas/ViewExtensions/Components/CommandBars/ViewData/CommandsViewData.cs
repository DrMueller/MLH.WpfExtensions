using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;

namespace Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Components.CommandBars.ViewData
{
    public class CommandsViewData
    {
        public IReadOnlyCollection<IViewModelCommand> Entries { get; }

        public CommandsViewData(params IViewModelCommand[] entries)
        {
            Guard.ObjectNotNull(() => entries);
            Entries = entries;
        }
    }
}