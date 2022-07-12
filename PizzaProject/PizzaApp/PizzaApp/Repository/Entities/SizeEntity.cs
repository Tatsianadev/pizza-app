using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzaApp.Repository.Entities
{
    [Table("Size")]
    public class SizeEntity
    {
        public SizeEntity()
        {
            this.PizzaPrices = new HashSet<PriceEntity>();
        }

        [Key]
        public int SizeID { get; set; }
        public string Size { get; set; }

        public virtual ICollection<PriceEntity> PizzaPrices { get; set; }
    }

}