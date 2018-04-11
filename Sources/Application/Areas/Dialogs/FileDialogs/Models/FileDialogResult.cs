using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Mlh.WpfExtensions.Areas.Dialogs.FileDialogs.Models
{
    public class FileDialogResult
    {
        public FileDialogResult(bool okClicked, string filePath)
        {
            OkClicked = okClicked;
            FilePath = filePath;
        }

        public string FilePath { get; }
        public bool OkClicked { get; }
    }
}
