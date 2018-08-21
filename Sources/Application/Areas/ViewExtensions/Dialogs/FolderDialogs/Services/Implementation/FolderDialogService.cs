using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Dialogs.FolderDialogs.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Dialogs.FolderDialogs.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StrctureMap")]
    internal class FolderDialogService : IFolderDialogService
    {
        public FolderDialogResult SelectFolder()
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    return new FolderDialogResult(true, folderBrowserDialog.SelectedPath);
                }

                return new FolderDialogResult(false, string.Empty);
            }
        }
    }
}