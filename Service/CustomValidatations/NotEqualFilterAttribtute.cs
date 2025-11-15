using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomValidatations
{
    public class NotEqualFilterAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public NotEqualFilterAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = value?.ToString();
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
            var comparisonValue = property?.GetValue(validationContext.ObjectInstance)?.ToString();

            if (currentValue == comparisonValue)
            {
                return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} must not be equal to {_comparisonProperty}.");
            }

            return ValidationResult.Success;
        }
    }

}
