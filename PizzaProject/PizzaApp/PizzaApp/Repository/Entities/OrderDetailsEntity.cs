using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaApp.Repository.Entities
{
    public class OrderDetailsEntity
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }

        public string CustomPizzaId { get; set; }

        public string Name { get; set; }

        public string PizzaImage { get; set; }

        public string Size { get; set; }
        public List<IngredientEntity> Ingredients { get; set; }
        public int Price { get; set; }
        public string ApplicationUserId { get; set; }
    }
}