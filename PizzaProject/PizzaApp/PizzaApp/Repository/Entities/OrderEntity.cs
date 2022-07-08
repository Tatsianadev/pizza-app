using PizzaApp.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzaApp.Repository.Entities
{
    [Table("Orders")]
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public string PizzaImage { get; set; }
        public string PizzaName { get; set; }
        public string  Size { get; set; }
        public Nullable<int> PizzaPrice { get; set; }

        public string ApplicationUser_Id { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}