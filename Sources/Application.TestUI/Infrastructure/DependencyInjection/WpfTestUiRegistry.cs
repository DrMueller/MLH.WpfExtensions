using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using StructureMap;

namespace Mmu.Mlh.WpfExtensions.TestUI.Infrastructure.DependencyInjection
{
    public class WpfTestUiRegistry : Registry
    {
        public WpfTestUiRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType(typeof(WpfTestUiRegistry));
                    scanner.AddAllTypesOf<IViewModel>();
                    scanner.AddAllTypesOf(typeof(IViewModelCommandContainer<>));
                    scanner.WithDefaultConventions();
                });

            For<IViewModel>().Transient();
        }
    }
}