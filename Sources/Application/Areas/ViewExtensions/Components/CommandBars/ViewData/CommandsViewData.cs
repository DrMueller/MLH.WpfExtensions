using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;

namespace Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Components.CommandBars.ViewData
{
    public class CommandsViewData
    {
        public IReadOnlyCollection<ViewModelCommand> Entries { get; }

        public CommandsViewData(IReadOnlyCollection<ViewModelCommand> entries)
        {
            Guard.ObjectNotNull(() => entries);

            Entries = entries;
        }
    }
}