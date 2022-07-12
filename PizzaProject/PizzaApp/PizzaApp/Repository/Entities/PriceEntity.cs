using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzaApp.Repository.Entities
{
    [Table("Price")]
    public class PriceEntity
    {
        [Key]
        public int PriceID { get; set; }
        public int PizzaID { get; set; }
        public int SizeID { get; set; }
        public int Price { get; set; }

        public virtual PizzaEntity Pizza { get; set; }
        public virtual SizeEntity PizzaSize { get; set; }
    }

}