using System;
using System.ComponentModel.DataAnnotations;

namespace Chefs_Dishes.Models
{
    public class EighteenYearsOld : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {   
            DateTime Birthday = (DateTime)value;
            int Age = DateTime.Now.Year - Birthday.Year;
            if(Birthday.DayOfYear > DateTime.Now.DayOfYear)
            {
                Age--;
            }
            if (Age < 18)
                return new ValidationResult("Sorry! This is not for kids. A Chef has to be 18.");
            return ValidationResult.Success;
        }
    }
}