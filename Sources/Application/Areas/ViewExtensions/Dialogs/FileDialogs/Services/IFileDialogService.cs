using Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Dialogs.FileDialogs.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Dialogs.FileDialogs.Services
{
    public interface IFileDialogService
    {
        FileDialogResult SelectFileName(string filter);
    }
}