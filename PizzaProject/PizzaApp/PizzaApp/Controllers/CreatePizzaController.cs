using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaApp.Controllers
{
    public class CreatePizzaController : Controller
    {
        // GET: CreatePizza
        public ActionResult CreatePizza()
        {
            return View();
        }
    }
}