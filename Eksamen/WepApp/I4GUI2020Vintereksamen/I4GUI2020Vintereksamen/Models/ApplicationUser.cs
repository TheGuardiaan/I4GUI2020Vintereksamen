using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace I4GUI2020Vintereksamen.Models
{

    // Add profile data for application users by adding properties to the ApplicationUser class
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
           
    }
    
}
