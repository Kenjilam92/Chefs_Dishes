using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chefs_Dishes.Models
{
    public class Chef
    {   
        [Key]
        public int ChefId {get;set;}
        [Required(ErrorMessage="Please type your First Name!")]
        public string FirstName {get;set;}
        [Required(ErrorMessage="Please type your Last Name!")]
        public string LastName {get;set;}
        // [Required][Range(18,Int32.MaxValue,ErrorMessage="Chef must be 18 years old or older ")]
        // public int Age {get;set;}
        [Required(ErrorMessage="Please choose your Birthday!")]
        [MustBePass][EighteenYearsOld]
        [DataType(DataType.Date)]
        public DateTime Birthday {get;set;}
        public DateTime CreateAt {get;set;} = DateTime.Now;
        public DateTime UpdateAt {get;set;} = DateTime.Now;
        // not in database
        public List<Dish> Dishes {get;set;}
    }
}