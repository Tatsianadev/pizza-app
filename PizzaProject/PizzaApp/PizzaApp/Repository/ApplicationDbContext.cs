using PizzaApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PizzaApp.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using PizzaApp.Models.Identity;

namespace PizzaApp.Repository
{
    //public class ApplicationDbContext : DbContext
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<PizzaEntity> Pizza { get; set; }
        public DbSet<SizeEntity> PizzaSize { get; set; }
        public DbSet<PriceEntity> PizzaPrice { get; set; }
        public DbSet<OrderEntity> Order { get; set; }
        public DbSet<IngredientEntity> Ingredients { get; set; }

        public DbSet<CustomPizzaIngredientsEntity> CustomPizzaIngredients { get; set; }


        public ApplicationDbContext() :
            base("PizzaDBEntities")
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<PizzaApp.Models.PizzaViewModel> PizzaViewModels { get; set; }
    }  
}