using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaApp.Models
{
    public class CreatePizzaViewModel
    {
        public string Name { get; set; }
        public List<SizeViewModel> Size { get; set; }

        public string SelectedSize { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; }
        //public Dictionary<IngredientViewModel,bool> Ingridients { get; set; }
        public int FinalPrice { get; set; }
    }
}