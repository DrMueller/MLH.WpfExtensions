using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Appearance.Models;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Appearance.Services
{
    public interface IAppearanceService
    {
        AppearanceTheme AppearanceTheme { get; set; }
    }
}