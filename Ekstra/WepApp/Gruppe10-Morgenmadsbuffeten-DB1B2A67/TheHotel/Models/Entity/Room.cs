using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheHotel.Data.Entity
{
    public class Room
    {

        public int RoomId { get; set; }

        [Required]
        [Display(Name = "Værelset nummer")]
        public string RoomNr { get; set; }

        //[Required]
        //[Display(Name = "Max Antal Gæster på Værelset")]
        //public int RoomSize { get; set; }

        [Display(Name = "Prisen")]
        public int Price { get; set; }

        [Required]
        [DefaultValue("false")]
        [Display(Name = "Værelse status")]
        public bool RoomStatus { get; set; }


        public ICollection<Guest> Guests { get; set; }
        public ICollection<FoodCheckIn> FoodCheckIns { get; set; }
    }
}

