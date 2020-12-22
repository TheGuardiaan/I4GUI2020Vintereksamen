using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheHotel.Data.Entity
{
    public class Guest
    {
        public int GuestId { get; set; }

        [Required]
        [RegularExpression(@"^[a-øA-Ø]+$", ErrorMessage = "Kun bogstaver er tilagt")]
        [Display(Name = "Fornavn")]
        public string FirstName { get; set; }


        [Required]
        [RegularExpression(@"^[a-øA-Ø]+$", ErrorMessage = "Kun bogstaver er tilagt")]
        [Display(Name = "Efternavn")]
        public string LastName { get; set; }


        [Display(Name = "Navn")]
        public string FullName { get; set; }

        //[Required]
        //[Display(Name = "FødselsDato")]
        //[DataType(DataType.Date)]
        //public DateTime DoB { get; set; }



        [MinLength(8, ErrorMessage = "Minmun Length is 6")]
        [MaxLength(8, ErrorMessage = "Maxmun Length is 6")]
        [Display(Name = "Telefon nummer")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Adresse")]
        public string Address { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        //public DateTime CheckInDay { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Reservere Tidspunkt")]
        public DateTime Reserve { get; set; }


        [Display(Name = "Antal Voksne")]
        [Range(1, 10)]
        public int NoAdults { get; set; }


        [Display(Name = "Antal Børn")]
        [Range(0, 5)]
        public int NoChildren { get; set; }



        public int RoomId { get; set; }
        public Room Room { get; set; }

        public ICollection<FoodCheckIn> FoodCheckIns { get; set; }
    }
}
