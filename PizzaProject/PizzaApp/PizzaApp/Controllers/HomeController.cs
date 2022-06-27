using PizzaApp.Models;
using PizzaApp.Repository;
using PizzaApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaApp.Controllers
{
    public class HomeController : Controller
    {

        public IRepository _repository;
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        //public ActionResult Register()
        //{
            
        //    return View();
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //public ActionResult Register(CustomerViewModel customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var customerEntity = new CustomerDataEntity()
        //            {
        //                Name = customer.Name,
        //                Login = customer.Login,
        //                Password=customer.Password,
        //                Address=customer.Address,
        //                Phone=customer.Phone,
        //                Email=customer.Email
        //            };

        //            return RedirectToAction("Index", "Home");
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }

        //    }

        //    return View(customer);
        //}

    }

    

}