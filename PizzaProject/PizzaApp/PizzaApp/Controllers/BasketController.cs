using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaApp.Models;
using PizzaApp.Repository;

namespace PizzaApp.Controllers
{
    public class BasketController : Controller
    {
        public IRepository _repository;

        public BasketController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: Basket
        public ActionResult Basket()
        {
            var orders = _repository.GetAllOrders();
            var orderModel = orders.Select(entity => new OrderViewModel()
            {
                Id= entity.Id,
                PizzaId= entity.PizzaId,
                PizzaImage= entity.PizzaImage,
                PizzaName=entity.PizzaName,
                PizzaPrice=entity.PizzaPrice,
                Size = entity.Size
            });
            var sum = 0;
            sum = (int)orderModel.Select(x => x.PizzaPrice).Sum();
          
            BasketViewModel basketModel=new BasketViewModel()
            {
                Orders = orderModel.ToList(),
                FinalPrice = sum
            };
            ViewBag.Counter = 1;
            return View(basketModel);
        }

        [HttpPost]
        [ActionName("Basket")]
        public ActionResult DeleteOrder(int id)
        {
            var order = _repository.GetOrder(id);
            if (order!=null)
            {
                bool result = _repository.DeleteOrder(order);
                if (result==true)
                {
                    return RedirectToAction("Basket","Basket");
                }
                else
                {
                    ModelState.AddModelError("", "Something goes wrong");
                }
            }
            ModelState.AddModelError("", "Order couldn't be find");
            return View("Basket");
            
            
            
        }

        public ActionResult ThankYou()
        {
            return View();
        }
    }
}