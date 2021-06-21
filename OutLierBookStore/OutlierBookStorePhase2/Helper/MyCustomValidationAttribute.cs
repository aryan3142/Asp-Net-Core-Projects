using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutlierBookStorePhase2.Helper
{
    public class MyCustomValidationAttribute : ValidationAttribute
    {
        public string text { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string bookname = value.ToString();
                if (bookname.Contains(text))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage ?? "The value doesn't contains 'mvc' ");
        }
    }
}
