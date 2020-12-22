using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheHotel.Data
{
    public class Kitchen
    {
       
        [Display(Name = "Find Dato")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }


        [Display(Name = "Voksne")]
        public int inAdult { get; set; }
        [Display(Name = "Børn")]
        public int inChildren { get; set; }
        [Display(Name = "Ialt")]
        public int sumIn { get => inAdult + inChildren; }



        [Display(Name = "Voksne")]
        public int expectedAdult { get; set; }      
        [Display(Name = "Børn")]
        public int expectedChildren { get; set; }
        [Display(Name = "Ialt")]
        public int countExpected { get => expectedAdult + expectedChildren; }



        [Display(Name = "Voksne")]
        public int notAdultSum { get => expectedAdult - inAdult; }
        [Display(Name = "Børn")]
        public int notChildrenSum { get => expectedChildren - inChildren; }
        [Display(Name = "Ialt")]
        public int sumNotsum { get => notChildrenSum + notAdultSum; }




    }
}
