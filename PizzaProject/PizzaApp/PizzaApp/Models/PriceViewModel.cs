using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaApp.Models
{
    public class PriceViewModel
    {
        [Key]
        public int PriceID { get; set; }
        public int PizzaID { get; set; }
        public int SizeID { get; set; }
        public int Price { get; set; }

        public virtual PizzaViewModel Pizza { get; set; }
        public virtual SizeViewModel PizzaSize { get; set; }
    }
}