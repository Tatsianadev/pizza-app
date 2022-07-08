using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PizzaApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaApp.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public ICollection<OrderEntity> Orders { get; set; } = new HashSet<OrderEntity>();

        public ApplicationUser()
        {
                
        }
        
       
    }
}