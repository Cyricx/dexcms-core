using System;
using System.ComponentModel.DataAnnotations;

namespace DexCMS.Core.Infrastructure.Attributes
{
    public class IsDateBeforeDateAttribute : ValidationAttribute
    {
        private readonly string _afterPropertyName;
        private readonly bool _allowEqualDates;

        public IsDateBeforeDateAttribute(string afterPropertyName, bool allowEqualDates = false)
        {
            _afterPropertyName = afterPropertyName;
            _allowEqualDates = allowEqualDates;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var afterProperty = validationContext.ObjectType.GetProperty(_afterPropertyName);
            if (afterProperty == null)
            {
                return new ValidationResult(string.Format("Unknown property {0}", _afterPropertyName));
            }

            var afterValue = afterProperty.GetValue(validationContext.ObjectInstance, null);

            if (value == null || !(value is DateTime))
            {
                return ValidationResult.Success;//not the job of this validator to check required
            }

            if (afterValue == null || !(afterValue is DateTime))
            {
                return ValidationResult.Success;//not the job of this validator to check required
            }

            //Compare Values
            if ((DateTime)value <= (DateTime)afterValue)
            {
                //if allow equal
                if (_allowEqualDates && value == afterValue)
                {
                    return ValidationResult.Success;
                }
                else if ((DateTime)value < (DateTime)afterValue)
                {
                    return ValidationResult.Success;
                }

            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));

        }

    }

}
