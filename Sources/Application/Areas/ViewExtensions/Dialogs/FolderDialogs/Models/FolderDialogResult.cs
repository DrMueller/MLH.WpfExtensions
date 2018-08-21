namespace Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Dialogs.FolderDialogs.Models
{
    public class FolderDialogResult
    {
        public FolderDialogResult(bool okClicked, string folderPath)
        {
            OkClicked = okClicked;
            FolderPath = folderPath;
        }

        public string FolderPath { get; }
        public bool OkClicked { get; }
    }
}