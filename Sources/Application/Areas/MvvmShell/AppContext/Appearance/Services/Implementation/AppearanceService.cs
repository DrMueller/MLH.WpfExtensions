using System;
using MaterialDesignThemes.Wpf;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Appearance.Models;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Appearance.Services.Handlers;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Appearance.Services.Implementation
{
    internal class AppearanceService : IAppearanceService
    {
        private const string RegistryKeyAppearanceTheme = "AppearanceTheme";
        private static readonly PaletteHelper _paletteHelper = new PaletteHelper();
        private readonly IRegistryHandler _registryHandler;

        public AppearanceService(IRegistryHandler registryHandler)
        {
            _registryHandler = registryHandler;
        }

        public AppearanceTheme AppearanceTheme
        {
            get
            {
                {
                    var savedTheme = _registryHandler.LoadFromCurrentUserApplicationRegistry(RegistryKeyAppearanceTheme);
                    var appearanceTheme = AppearanceTheme.Light;
                    if (!string.IsNullOrEmpty(savedTheme))
                    {
                        appearanceTheme = (AppearanceTheme)Enum.Parse(typeof(AppearanceTheme), savedTheme);
                    }

                    return appearanceTheme;
                }
            }
            set
            {
                _paletteHelper.SetLightDark(value == AppearanceTheme.Dark);
                _registryHandler.SaveIntoCurrentUserApplicationRegistry(RegistryKeyAppearanceTheme, value.ToString());
            }
        }
    }
}