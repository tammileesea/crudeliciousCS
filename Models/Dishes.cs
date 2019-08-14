using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models {
    public class Dish {
        [Key]
        public int iddishes {get;set;}

        [Required]
        [MinLength(2, ErrorMessage = "Dish name must be at least 2 characters")]
        [Display(Name = "Dish Name")]
        public string Name {get;set;}

        [Required]
        [MinLength(2, ErrorMessage = "Chef's name must be at least 2 characters")]
        [Display(Name = "Chef's Name")]
        public string Chef {get;set;}

        [Required]
        [Range(1, 6, ErrorMessage = "Tastiness level must be between 1 and 5")]        
        [Display(Name = "Tastiness")]
        public int Tastiness {get;set;}

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Calorie count must be at least 0")]
        [Display(Name = "# of Calories")]
        public int Calories {get;set;}

        [Required]
        [MinLength(20, ErrorMessage = "Description must be at least 20 characters")]
        [Display(Name = "Description")]
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}