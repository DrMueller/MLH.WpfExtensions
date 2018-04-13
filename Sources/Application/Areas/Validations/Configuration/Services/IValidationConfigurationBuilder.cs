namespace Mmu.Mlh.WpfExtensions.Areas.Validations.Configuration.Services
{
    public interface IValidationConfigurationBuilder
    {
        IPropertyValidationConfigurationBuilder ForProperty(string propertyName);
    }
}