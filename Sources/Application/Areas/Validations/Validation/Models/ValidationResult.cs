namespace Mmu.Mlh.WpfExtensions.Areas.Validations.Validation.Models
{
    public class ValidationResult
    {
        public string ErrorMessage { get; }
        public bool IsValid { get; }

        public ValidationResult(bool isValid, string errorMessage)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }

        public static ValidationResult CreateInvalid(string errorMessage)
        {
            return new ValidationResult(false, errorMessage);
        }

        public static ValidationResult CreateValid()
        {
            return new ValidationResult(true, string.Empty);
        }
    }
}