using System.Threading.Tasks;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors.Shapings
{
    public interface IInitializableViewModel : IViewModelWithBehaviorBase
    {
        Task InitializeAsync();
    }
}