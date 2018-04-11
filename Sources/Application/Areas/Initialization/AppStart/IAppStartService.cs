using System.Reflection;

namespace Mmu.Mlh.WpfExtensions.Areas.Initialization.AppStart
{
    internal interface IAppStartService
    {
        void StartUp(Assembly rootAssembly);
    }
}