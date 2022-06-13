using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace PizzaApp.Models
{
    public class PizzaViewModel
    {
        public PizzaViewModel()
        {
            this.PizzaPrices = new HashSet<PriceViewModel>();
        }

        [Key]
        public int PizzaID { get; set; }
        public string PizzaName { get; set; }
        public string ImageFile { get; set; }
        
        public int PizzaPriceDefault { get; set; }

        public virtual ICollection<PriceViewModel> PizzaPrices { get; set; }
    }
}