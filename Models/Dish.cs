using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chefs_Dishes.Models
{
    public class Dish
    {   
        [Key]
        public int DishId {get;set;}
        [Required(ErrorMessage="Please give this dish a name")]
        [Display(Name="Name")]
        public string DishName {get;set;}
        [Required(ErrorMessage="Please calculate this dish calories")]
        [Range(0,Int32.MaxValue)]
        public int Calories {get;set;}
        [Required]
        [Range(1,5)]
        public int Tastiness {get;set;}
        [Required]
        public string Description {get;set;}
        [Required]
        [Display(Name="Chef")]
        public int ChefId {get;set;}
        public DateTime UpdateAt {get;set;} = DateTime.Now;
        public DateTime CreateAt {get;set;} = DateTime.Now;
        // not in database
        public Chef Chef {get;set;} 
    }
}