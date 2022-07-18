using PizzaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaApp.Controllers
{
    public class CreatedPizzaController : Controller
    {
        // GET: CreatedPizza
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(OrderViewModel createdPizza)
        {
            return View();
        }
    }
}