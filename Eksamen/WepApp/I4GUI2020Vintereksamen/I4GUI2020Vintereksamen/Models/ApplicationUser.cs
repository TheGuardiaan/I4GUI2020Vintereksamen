using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace I4GUI2020Vintereksamen.Models
{

    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
        {

            [Required]
            [Display(Name = "Fornavn")]
            [StringLength(50, MinimumLength = 3)]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Efternavn")]
            [StringLength(50, MinimumLength = 3)]
            public string LastName { get; set; }

            [Display(Name = "Fulde Nave")]
            public string FullName
            {
                get { return LastName + ", " + FirstName; }
            }

            [Display(Name = "Profil billede")]
            public string ImagePath { get; set; }


            [Display(Name = "Sidste 4-CPR")]
            [Range(0, 4)]
            public int? SNN { get; set; }


            [Display(Name = "Fødselsdags Dato")]
            [DataType(DataType.Date)]
            public DateTime? Dob { get; set; }


           
        }
    
}
