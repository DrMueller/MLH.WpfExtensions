using System.Reflection;

namespace Mmu.Mlh.WpfExtensions.Areas.Initialization.ViewModelMapping.Services
{
    public interface IViewModelMappingService
    {
        void Initialize(Assembly rootAssembly);
    }
}