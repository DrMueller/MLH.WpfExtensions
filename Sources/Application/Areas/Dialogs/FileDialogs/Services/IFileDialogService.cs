using Mmu.Mlh.WpfExtensions.Areas.Dialogs.FileDialogs.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.Dialogs.FileDialogs.Services
{
    public interface IFileDialogService
    {
        FileDialogResult SelectFileName(string filter);
    }
}