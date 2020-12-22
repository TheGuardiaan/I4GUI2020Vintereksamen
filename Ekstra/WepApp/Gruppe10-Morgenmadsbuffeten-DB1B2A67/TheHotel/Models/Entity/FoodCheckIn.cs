using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheHotel.Data.Entity
{
    public class FoodCheckIn
    {
        public int FoodCheckInId { get; set; }


        [Required]
        [Display(Name = "Tjek ind tid")]
        public DateTime CheckInDate { get; set; }



        public int? RoomId { get; set; }
        public Room Room { get; set; }

        public int GuestId { get; set; }
        public Guest Guest { get; set; }


        [Required]
        [Display(Name = "Voksne")]
        public bool Adults { get; set; }

        [Required]
        [Display(Name = "Børn")]
        public bool Children { get; set; }

    }
}
