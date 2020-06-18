using System;
using System.ComponentModel.DataAnnotations;

namespace Chefs_Dishes.Models
{
    public class MustBePass : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((DateTime) value >= DateTime.Now)
                return new ValidationResult("Sorry! We are not playing 'Back to the Future'.");
            return ValidationResult.Success;
        }
    }
}