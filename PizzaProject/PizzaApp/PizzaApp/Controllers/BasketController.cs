﻿using System;
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
                PizzaPrice=entity.PizzaPrice
            });
            var sum = 0;
            sum = (int)orderModel.Select(x => x.PizzaPrice).Sum();
            //foreach (var order in orderModel)
            //{
            //    sum =(int) (sum + order.PizzaPrice);
                
            //}
            BasketViewModel basketModel=new BasketViewModel()
            {
                Orders = orderModel.ToList(),
                FinalPrice = sum
            };

            return View(basketModel);
        }
    }
}