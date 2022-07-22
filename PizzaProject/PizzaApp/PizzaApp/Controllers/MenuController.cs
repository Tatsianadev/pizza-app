using PizzaApp.Models;
using PizzaApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaApp.Controllers
{
    public class MenuController : Controller
    {
        public IRepository Repository;
        public MenuController(IRepository repository)
        {
            this.Repository = repository;
        }

       
        // GET: Menu
        public ActionResult Menu()
        {
            var data = Repository.GetAllPizzas();
            int sizeIdDefault = 1;
            
            var pizzaModels = data.Select(entity => new PizzaViewModel()
            {
                PizzaID = entity.PizzaID,
                PizzaName = entity.PizzaName,
                ImageFile = entity.ImageFile,
                PizzaPriceDefault = Repository.GetPrice(entity.PizzaID, sizeIdDefault).Price

            }).Where(x=>x.PizzaName!="CustomerPizza");


            var pizzas = pizzaModels.ToList();
            
            return View(pizzas);
        }


    }
}