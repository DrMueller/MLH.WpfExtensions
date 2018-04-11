using System.Reflection;
using System.Threading.Tasks;

namespace Mmu.Mlh.WpfExtensions.Areas.Initialization.AppStart
{
    internal interface IAppStartService
    {
        Task StartUpAsync(Assembly rootAssembly);
    }
}