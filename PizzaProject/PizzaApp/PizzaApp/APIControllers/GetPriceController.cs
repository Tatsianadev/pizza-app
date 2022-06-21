using PizzaApp.Repository;
using PizzaApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaApp.Models;
using System.Configuration;

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
        public string AddOrderToDb(int pizzaId, int price, string size)
        {
            var pizza = _repository.GetPizza(pizzaId);
            var order = new OrderEntity()
            {
                PizzaId = pizza.PizzaID,
                PizzaName = pizza.PizzaName,
                PizzaImage = pizza.ImageFile,
                PizzaPrice = price,
                Size = size
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

       



        [HttpGet]
        public (int,int) CountPriceBySize(string size, int sizeBefore, int price)
        {
            var config = ConfigurationManager.AppSettings.Get("defaultPrice");

            var sizeElement = _repository.GetSizeId(size);
            var sizeId = sizeElement.SizeID;

            


            if (sizeId!= sizeBefore)
            {
                if (sizeId> sizeBefore)
                {
                    if (sizeId- sizeBefore == 1)
                    {
                        price += 1;
                    }
                    if (sizeId - sizeBefore == 2)
                    {
                        price += 2;
                    }

                }
                if (sizeId<sizeBefore)
                {
                    if (sizeBefore - sizeId==1)
                    {
                        price -= 1;
                    }
                    if (sizeBefore - sizeId == 2)
                    {
                        price -= 2;
                    }
                }

            }

            sizeBefore = sizeId;
            //var data = new List<int>();
            //data.Add(price);
            //data.Add(sizeBefore);

            return (price,sizeBefore);

        }

    }
}