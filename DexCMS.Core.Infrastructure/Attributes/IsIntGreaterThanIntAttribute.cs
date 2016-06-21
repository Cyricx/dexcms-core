using System.ComponentModel.DataAnnotations;

namespace DexCMS.Core.Infrastructure.Attributes
{
    public class IsIntGreaterThanIntAttribute : ValidationAttribute
    {
        private readonly string _minPropertyName;
        private readonly bool _allowEqualValues;

        public IsIntGreaterThanIntAttribute(string minPropertyName, bool allowEqualValues = false)
        {
            _minPropertyName = minPropertyName;
            _allowEqualValues = allowEqualValues;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var minProperty = validationContext.ObjectType.GetProperty(_minPropertyName);
            if (minProperty == null)
            {
                return new ValidationResult(string.Format("Unknown property {0}", _minPropertyName));
            }

            var minValue = minProperty.GetValue(validationContext.ObjectInstance, null);

            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (minValue == null)
            {
                return ValidationResult.Success;
            }

            //Compare Values
            if ((int)value >= (int)minValue)
            {
                //if allow equal
                if (_allowEqualValues && (int)value == (int)minValue)
                {
                    return ValidationResult.Success;
                }
                else if ((int)value > (int)minValue)
                {
                    return ValidationResult.Success;
                }

            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));

        }

    }
}
