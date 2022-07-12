using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaApp.Models
{
    public class CreatePizzaViewModel
    {
        [Required(ErrorMessage = "Give your pizza name")]
        [StringLength(30, ErrorMessage = "Too long name. Do name shorter")]
        public string Name { get; set; }

        public List<SizesPrizesViewModel> SizePrice { get; set; }

        [Required(ErrorMessage = "Choose size")]
        public string SelectedSize { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; }
        
        public int FinalPrice { get; set; }
       
    }
}