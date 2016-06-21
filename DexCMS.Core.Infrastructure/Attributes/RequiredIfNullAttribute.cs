using System.ComponentModel.DataAnnotations;

namespace DexCMS.Core.Infrastructure.Attributes
{
    public class RequiredIfNullAttribute : ValidationAttribute
    {
        private readonly string _nullablePropertyName;

        public RequiredIfNullAttribute(string nullablePropertyNme)
        {
            _nullablePropertyName = nullablePropertyNme;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var nullableProperty = validationContext.ObjectType.GetProperty(_nullablePropertyName);
            if (nullableProperty == null)
            {
                return new ValidationResult(string.Format("Unknown property {0}", _nullablePropertyName));
            }

            var nullableValue = nullableProperty.GetValue(validationContext.ObjectInstance, null);

            if (nullableValue != null || value != null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));


        }
    }

}
