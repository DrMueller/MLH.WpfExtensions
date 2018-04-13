namespace Mmu.Mlh.WpfExtensions.Areas.Validations.Validation.Models
{
    public class ValidationResult
    {
        public ValidationResult(bool isValid, string errorMessage)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
        public bool IsValid { get; }

        public static ValidationResult CreateInvalid(string errorMessage) => new ValidationResult(false, errorMessage);

        public static ValidationResult CreateValid() => new ValidationResult(true, string.Empty);
    }
}