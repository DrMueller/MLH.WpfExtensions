namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Appearance.Services.Handlers
{
    public interface IRegistryHandler
    {
        string LoadFromCurrentUserApplicationRegistry(string keyName);

        void SaveIntoCurrentUserApplicationRegistry(string keyName, string value);
    }
}