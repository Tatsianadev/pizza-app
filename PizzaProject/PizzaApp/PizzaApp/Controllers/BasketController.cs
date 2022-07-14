using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaApp.Models;
using PizzaApp.Repository;
using PizzaApp.Repository.Entities;

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
        //public ActionResult Basket()
        //{
        //    var orders = _repository.GetAllOrders();
        //    var orderModel = orders.Select(entity => new OrderViewModel()
        //    {
        //        Id= entity.Id,
        //        PizzaId= entity.PizzaId,
        //        PizzaImage= entity.PizzaImage,
        //        PizzaName=entity.PizzaName,
        //        PizzaPrice=entity.PizzaPrice,
        //        Size = entity.Size
        //    });
        //    var sum = 0;
        //    sum = (int)orderModel.Select(x => x.PizzaPrice).Sum();
          
        //    BasketViewModel basketModel=new BasketViewModel()
        //    {
        //        Orders = orderModel.ToList(),
        //        FinalPrice = sum
        //    };
        //    ViewBag.Counter = 1;
        //    return View(basketModel);
        //}

        public ActionResult Basket()
        {
            var pizzas = _repository.GetAllPizzas();
            var sizes = _repository.GetAllSizes();
            var prices = _repository.GetAllPrices();
            var orders = _repository.GetAllOrders();

            var customPizzas = _repository.GetAllCustomPizzas();

            var orderModel = from order in orders
                             join pizza in pizzas on order.PizzaId equals pizza.PizzaID into table1
                             from pizza in table1.DefaultIfEmpty().ToList()
                             join size in sizes on order.SizeId equals size.SizeID into table2
                             from size in table2.DefaultIfEmpty()
                             join price in prices on
                             new { x1 = order.PizzaId, x2 = order.SizeId } equals
                             new { x1 = price.PizzaID, x2 = price.SizeID } into table3
                             from price in table3.DefaultIfEmpty()
                             //join ingredient in customPizzas on order.CustomPizzaId equals ingredient.CustomPizzaId into table4
                             //from ingredient in table4.DefaultIfEmpty()
                             
                             select new OrderViewModel()
                             {
                                 Id = order.Id,
                                 PizzaName = pizza.PizzaName,
                                 PizzaImage = pizza.ImageFile,
                                 Size = size.Size,
                                 PizzaPrice = price.Price
                             };

            //var customOrderModel = from order in orders
            //                       join customPizza in customPizzas on order.CustomPizzaId equals customPizza.CustomPizzaId into table4
            //                       from customPizza in table4.DefaultIfEmpty().ToList()
            //                       join size in sizes on order.SizeId equals size.SizeID into table5
            //                       from size in table5.DefaultIfEmpty()
            //                       join price in prices on
            //                 new { x1 = 16, x2 = order.SizeId } equals
            //                 new { x1 = price.PizzaID, x2 = price.SizeID } into table6
            //                       from price in table6.DefaultIfEmpty()
            //                       select new OrderViewModel()
            //                       {
            //                           Id = order.Id,
            //                           PizzaName = customPizza.Name,
            //                           PizzaImage = "Create.jpg",
            //                           Size = size.Size,
            //                           PizzaPrice = price.Price + _repository.GetCustomPizzaPrice(customPizza.CustomPizzaId)
            //                       };

           

            var finalPrice = 0;
            //finalPrice = orderModel.Select(x => x.PizzaPrice).Sum()+ customOrderModel.Select(x => x.PizzaPrice).Sum();
            finalPrice = orderModel.Select(x => x.PizzaPrice).Sum();


            BasketViewModel basketModel = new BasketViewModel()
            {
                Orders = orderModel.ToList(),
                //CustomOrders=customOrderModel.ToList(),
                FinalPrice = finalPrice
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



//var orderModel = orders.Select(entity => new OrderViewModel()
//{
//    Id = entity.Id,
//    PizzaId = entity.PizzaId,
//    PizzaImage = _repository.GetPizza(entity.Id).ImageFile,
//    PizzaName = _repository.GetPizza(entity.Id).PizzaName,
//    PizzaPrice = _repository.GetPrice(entity.PizzaId, entity.SizeId).Price,
//    Size = _repository.GetSize(entity.SizeId).Size
//});