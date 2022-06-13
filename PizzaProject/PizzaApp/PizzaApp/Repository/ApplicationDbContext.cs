using PizzaApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PizzaApp.Models;


namespace PizzaApp.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<PizzaEntity> Pizza { get; set; }
        public DbSet<SizeEntity> PizzaSize { get; set; }
        public DbSet<PriceEntity> PizzaPrice { get; set; }
        public DbSet<OrderEntity> Order { get; set; }

        public ApplicationDbContext() :
            base("PizzaDBEntities")
        {

        }

        public System.Data.Entity.DbSet<PizzaApp.Models.PizzaViewModel> PizzaViewModels { get; set; }
    }  
}