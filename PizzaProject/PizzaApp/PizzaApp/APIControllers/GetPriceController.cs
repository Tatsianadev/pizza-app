using PizzaApp.Repository;
using PizzaApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaApp.Models;
using System.Configuration;
using PizzaApp.Models.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

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


        //Before User-Order reference

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



        //Before User-Order reference

        //[HttpGet]
        //[Route("addorder")]
        //public async Task<string> AddOrderToDb(int pizzaId, int price, string size, string userName)
        //{
        //    ApplicationUser user = await UserManager.FindByNameAsync(userName);
        //    var id = user.Id;

        //    var pizza = _repository.GetPizza(pizzaId);
        //    var order = new OrderEntity()
        //    {
        //        PizzaId = pizza.PizzaID,
        //        PizzaName = pizza.PizzaName,
        //        PizzaImage = pizza.ImageFile,
        //        PizzaPrice = price,
        //        Size = size,
        //        ApplicationUserId=id
        //    };
        //    _repository.AddOrder(order);
        //    return "pizza in basket";
        //}



        [HttpGet]
        [Route("addorder")]
        public async Task<string> AddOrderToDb(int pizzaId, int size, string userName)
        {
            ApplicationUser user = await UserManager.FindByNameAsync(userName);
            var id = user.Id;

            var pizza = _repository.GetPizza(pizzaId);

            var order = new OrderEntity()
            {
                PizzaId = pizza.PizzaID,
                SizeId = size,
                ApplicationUserId = id
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
            var pizzaId = _repository.GetAllPizzas().FirstOrDefault(x => x.PizzaName == "CustomerPizza").PizzaID;
            var sizeId = _repository.GetSizeId(size).SizeID;
            var price = _repository.GetPrice(pizzaId, sizeId).Price;

            if (arrId != null)
            {
                foreach (var item in arrId)
                {
                    var ingredient = _repository.GetIngredient(item);
                    price += ingredient.Price;
                }
            }

            return price;
        }









        //Переделать для Created Pizza после изменения таблицы orders (код был рабочим до изменения orders) 

        //[HttpGet]

        //public async Task<string> AddCreatedPizzaToOrder(string customPizzaId, string size, string userName)
        //{
        //    ApplicationUser user = await UserManager.FindByNameAsync(userName);
        //    var userId = user.Id;

        //    var SizeId = _repository.GetSizeId(size).SizeID;
        //    var pizzaId = _repository.GetAllPizzas().Where(x => x.PizzaName == "CustomerPizza").FirstOrDefault().PizzaID;
        //    var createdPizza = new OrderEntity()
        //    {
        //        PizzaId=pizzaId,
        //       CustomPizzaId=customPizzaId,
        //        SizeId = SizeId,
        //        ApplicationUserId= userId
        //    };
        //    _repository.AddOrder(createdPizza);
        //    return "pizza added to order";
        //}


        [HttpPost]

        public async Task<string> AddCreatedPizzaToOrder(string customPizzaId, string size, string name, string userName, Array ingredients)
        {
            ApplicationUser user = await UserManager.FindByNameAsync(userName);
            var userId = user.Id;

            var sizeId = _repository.GetSizeId(size).SizeID;
            var pizzaId = _repository.GetAllPizzas().Where(x => x.PizzaName == "CustomerPizza").FirstOrDefault().PizzaID;
            var createdPizza = new OrderEntity()
            {
                PizzaId = pizzaId,
                CustomPizzaId = customPizzaId,
                SizeId = sizeId,
                ApplicationUserId = userId
            };
            _repository.AddOrder(createdPizza);

            
            foreach (var item in ingredients)
            {
                var ingrId = _repository.GetAllIngredients().FirstOrDefault(x => x.Name == item.ToString()).Id;
                var pizzaIngredient = new CustomPizzaIngredientsEntity()
                {
                    OrderId=createdPizza.Id,
                    CustomPizzaId = customPizzaId,
                    IngredientId = ingrId,
                    Name = name
                };
                _repository.AddCustomPizza(pizzaIngredient);

            }

            return "pizza added to order";
        }
    }



}