using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzaApp.Repository.Entities
{
    [Table("CustomPizzaIngredients")]
    public class CustomPizzaIngredientsEntity
    {
        [Key]
        public int Id { get; set; }
       
        public string CustomPizzaId { get; set; }
        public string Name { get; set; }

        public int IngredientId { get; set; }
        
    }
}