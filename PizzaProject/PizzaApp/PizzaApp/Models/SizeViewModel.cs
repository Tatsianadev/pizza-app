using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaApp.Models
{
    public class SizeViewModel
    {
        public SizeViewModel()
        {
            this.PizzaPrices = new HashSet<PriceViewModel>();
        }

        [Key]
        public int SizeID { get; set; }
        public string Size { get; set; }

        public virtual ICollection<PriceViewModel> PizzaPrices { get; set; }
    }
}