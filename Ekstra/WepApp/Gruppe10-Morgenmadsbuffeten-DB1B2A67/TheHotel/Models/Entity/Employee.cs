using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheHotel.Data.Entity
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "Fornavn")]
        [RegularExpression(@"^[a-øA-Ø]+$", ErrorMessage = "Kun bogstaver er tilagt")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-øA-Ø]+$", ErrorMessage = "Kun bogstaver er tilagt")]
        [Display(Name = "Efternavn")]
        public string LastName { get; set; }


        [Display(Name = "Fødselsdags Dato")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Required]
        [Display(Name = "De Sidste 4 Cifre I CPR-Nr")]
        [MinLength(4, ErrorMessage = "Minmun Length is 4")]
        [MaxLength(4, ErrorMessage = "Maxmun Length is 4")]
        public string SSN { get; set; }

        [Display(Name = "Profil Foto")]
        public string Image { get; set; }

  
        public int PositionId { get; set; }
        public Position position { get; set; }





    }
}
