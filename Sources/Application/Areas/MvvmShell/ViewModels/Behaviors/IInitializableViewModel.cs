using System.Threading.Tasks;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors
{
    public interface IInitializableViewModel : IViewModelWithBehaviorBase
    {
        Task InitializeAsync();
    }
}