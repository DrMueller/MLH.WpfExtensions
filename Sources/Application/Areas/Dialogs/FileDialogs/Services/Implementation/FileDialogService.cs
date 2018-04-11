using System.Windows.Forms;
using Mmu.Mlh.WpfExtensions.Areas.Dialogs.FileDialogs.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.Dialogs.FileDialogs.Services.Implementation
{
    public class FileDialogService : IFileDialogService
    {
        public FileDialogResult SelectFileName(string filter)
        {
            var openFileDialog = new OpenFileDialog { Filter = filter };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return new FileDialogResult(true, openFileDialog.FileName);
            }

            return new FileDialogResult(false, string.Empty);
        }
    }
}