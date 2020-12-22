using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TheHotel.Models;

namespace TheHotel.Data.Entity
{
    public class Position
    {
        public int PositionId { get; set; }

        
        [Required]
        [Display(Name = "Stilling")]
        public string PositionName { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
