using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Dialogs.FileDialogs.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Dialogs.FileDialogs.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StrctureMap")]
    internal class FileDialogService : IFileDialogService
    {
        public FileDialogResult SelectFileName(string filter)
        {
            using (var openFileDialog = new OpenFileDialog { Filter = filter })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return new FileDialogResult(true, openFileDialog.FileName);
                }

                return new FileDialogResult(false, string.Empty);
            }
        }
    }
}