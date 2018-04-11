using System.Windows;
using Mmu.Mlh.WpfExtensions.Areas.Initialization.ViewModelMapping.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.Initialization.ViewModelMapping.Services.Handlers
{
    internal interface IDataTemplateFactory
    {
        DataTemplate CreateWithMapping(ViewViewModelMap map);
    }
}