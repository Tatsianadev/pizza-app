using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzaApp.Repository.Entities
{
    [Table("SizesPrices")]
    public class SizesPricesEntity
    {
        public int Id { get; set; }
        public int Price { get; set; }

        public string Size { get; set; }
    }
}