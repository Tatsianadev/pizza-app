using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaApp.Models
{
    public class OrderViewModel
    {
        [Key]
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public string PizzaImage { get; set; }
        public string PizzaName { get; set; }
        public string Size { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; }
        public Nullable<int> PizzaPrice { get; set; }
    }
}