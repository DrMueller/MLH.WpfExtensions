using System;
using System.Threading.Tasks;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.Validations.Configuration.Services;
using Mmu.Mlh.WpfExtensions.Areas.Validations.ValidationExpressions;
using Mmu.Mlh.WpfExtensions.TestUI.Areas.ValidationTests.ViewModels.ViewModelCommands;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.ValidationTests.ViewModels
{
    public class SimpleValidationViewModel : ViewModelWithValidation, IMainNavigationViewModel, IViewModelWithHeading
    {
        private readonly SimpleValidationViewModelCommands _commands;

        private DateTime _birthDate;

        private string _firstName;

        public SimpleValidationViewModel(SimpleValidationViewModelCommands commands) => _commands = commands;

        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                if (_birthDate == value)
                {
                    return;
                }

                _birthDate = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName == value)
                {
                    return;
                }

                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string HeadingText { get; } = "Simple Validation";
        public string NavigationDescription { get; } = "Validation Simple";
        public int NavigationSequence { get; } = 2;
        public ViewModelCommand ValidateStuff => _commands.ValidateStuff;

        protected override void ConfigureValidation(IValidationConfigurationBuilder builder)
        {
            builder.ForProperty(nameof(FirstName))
                .AddExpression(ExpressionFactory.StringNotNullOrEmpty())
                .AddExpression(ExpressionFactory.StringLength(0, 5))
                .BuildPropertyValidation();
        }

        protected override async Task InitializeAsnc()
        {
            await _commands.InitializeAsync(this);
        }
    }
}