using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TheHotel.Data.Entity;

namespace TheHotel.Models
{

    // Add profile data for application users by adding properties to the ApplicationHotelUser class
    public class ApplicationUser : IdentityUser
        {

            [PersonalData]
            [Column(TypeName = "nvarchar(100)")]
            public string FirstName { get; set; }

            [PersonalData]
            [Column(TypeName = "nvarchar(100)")]
            public string LastName { get; set; }


            [Display(Name = "Fødselsdags Dato")]
            [DataType(DataType.Date)]
            public DateTime Dob { get; set; }
           
            //[Display(Name = "De Sidste 4 Cifre I CPR-Nr")]
            //[MinLength(4, ErrorMessage = "Minmun Length is 4")]
            //[MaxLength(4, ErrorMessage = "Maxmun Length is 4")]
            //public string SSN { get; set; }

            //[Display(Name = "Profil Foto")]
            //public string Image { get; set; }

            [Required]
            [Display(Name = "Stilling")]
            public string PositionName { get; set; }

    }
    
}
