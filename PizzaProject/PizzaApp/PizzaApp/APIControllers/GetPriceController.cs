using PizzaApp.Repository;
using PizzaApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        // GET: GetPrice
        [HttpGet]
        [Route("getprice")]
        public string GetPrice(int id, int size)
        {
            var price = _repository.GetPrice(id, size).Price;
            return price.ToString();
        }

        [HttpGet]
        [Route("addorder")]
        public string AddOrderToDb(int pizzaId, int price)
        {
            var pizza = _repository.GetPizza(pizzaId);
            var order = new OrderEntity()
            {
                PizzaId = pizza.PizzaID,
                PizzaName = pizza.PizzaName,
                PizzaImage = pizza.ImageFile,
                PizzaPrice = price
            };
            _repository.AddOrder(order);
            return "pizza in basket";
        }

        [HttpGet]
        [Route("delete")]
        public bool DeleteOrder(int orderId)
        {
            var order = _repository.GetOrder(orderId);
            _repository.DeleteOrder(order);
            return true;
        }
    }
}