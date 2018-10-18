namespace Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Dialogs.FileDialogs.Models
{
    public class FileDialogResult
    {
        public string FilePath { get; }
        public bool OkClicked { get; }

        public FileDialogResult(bool okClicked, string filePath)
        {
            OkClicked = okClicked;
            FilePath = filePath;
        }
    }
}