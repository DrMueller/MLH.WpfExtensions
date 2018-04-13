using System.Threading.Tasks;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.ValidationTests.ViewModels.ViewModelCommands
{
    public class SimpleValidationViewModelCommands : IViewModelCommandContainer<SimpleValidationViewModel>
    {
        public ViewModelCommand ValidateStuff { get; private set; }

        public Task InitializeAsync(SimpleValidationViewModel context)
        {
            return Task.Run(
                () =>
                {
                    ValidateStuff = new ViewModelCommand(
                        "Validate stuff!",
                        new RelayCommand(
                            () =>
                            {
                            }));
                });
        }
    }
}