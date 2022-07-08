﻿using PizzaApp.Repository;
using PizzaApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaApp.Models;
using System.Configuration;
using PizzaApp.Models.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace PizzaApp.APIControllers
{
    [Route("api")]
    public class GetPriceController : Controller
    {
        public IRepository _repository;

        public GetPriceController(IRepository repository)
        {
            _repository = repository;
        }

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        // GET: GetPrice
        [HttpGet]
        [Route("getprice")]
        public string GetPrice(int id, int size)
        {
            var price = _repository.GetPrice(id, size).Price;
            return price.ToString();
        }

        //[HttpGet]
        //[Route("addorder")]
        //public string AddOrderToDb(int pizzaId, int price, string size)
        //{
        //    var pizza = _repository.GetPizza(pizzaId);
        //    var order = new OrderEntity()
        //    {
        //        PizzaId = pizza.PizzaID,
        //        PizzaName = pizza.PizzaName,
        //        PizzaImage = pizza.ImageFile,
        //        PizzaPrice = price,
        //        Size = size
        //    };

        //    _repository.AddOrder(order);
        //    return "pizza in basket";
        //}

        [HttpGet]
        [Route("addorder")]
        public async Task<string> AddOrderToDb(int pizzaId, int price, string size, string userName)
        {
           ApplicationUser user = await UserManager.FindByNameAsync(userName);
            var id = user.Id;
            var pizza = _repository.GetPizza(pizzaId);
            var order = new OrderEntity()
            {
                PizzaId = pizza.PizzaID,
                PizzaName = pizza.PizzaName,
                PizzaImage = pizza.ImageFile,
                PizzaPrice = price,
                Size = size,
                ApplicationUser_Id = id
            };

            _repository.AddOrder(order);
            return "pizza in basket";
        }


        //  method is valiable. Use to change without refresh page

        //[HttpGet]
        //[Route("delete")]
        //public bool DeleteOrder(int orderId)
        //{
        //    var order = _repository.GetOrder(orderId);
        //    _repository.DeleteOrder(order);
        //    return true;
        //}

        [HttpGet]
        public int CountPrice(List<int> arrId, string size)
        {
            var price = _repository.GetPriceBySize(size).Price;

            if (arrId!=null)
            {
                foreach (var item in arrId)
                {
                    var ingredient = _repository.GetIngredient(item);
                    price += ingredient.Price;
                }
            }
         
            return price;
        }

        

        [HttpPost]

        public string AddCreatedPizzaToOrder(int Id, int PizzaId, string Name, string Size, int Price)
        {
           
            var createdPizzaImage = ConfigurationManager.AppSettings["CreatedPizzaImage"];
            var createdPizza = new OrderEntity()
            {
                Id = Id,
                PizzaId = PizzaId,
                PizzaName = Name,
                PizzaImage = createdPizzaImage,
                Size = Size,
                PizzaPrice = Price
            };
            _repository.AddOrder(createdPizza);
            return "pizza added to order";
        }
    }
}