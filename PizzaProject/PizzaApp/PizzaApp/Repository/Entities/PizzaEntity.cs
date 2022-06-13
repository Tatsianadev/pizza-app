using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzaApp.Repository.Entities
{
    [Table("Pizza")]
    public class PizzaEntity
    {
        public PizzaEntity()
        {
            this.PizzaPrices = new HashSet<PriceEntity>();
        }

        [Key]
        public int PizzaID { get; set; }
        public string PizzaName { get; set; }
        public string ImageFile { get; set; }

        public virtual ICollection<PriceEntity> PizzaPrices { get; set; }
    }
}