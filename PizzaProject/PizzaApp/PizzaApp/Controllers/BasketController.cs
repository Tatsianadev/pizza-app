using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PizzaApp.Models;
using PizzaApp.Models.Identity;
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

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }


        public async Task<ActionResult> Basket()
        {
            ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);
            var userId = user.Id;

            var orderDetails = _repository.GetOrderDetails().Where(x => x.ApplicationUserId == userId).ToList();
            var orderModel = orderDetails.Select(entity => new OrderViewModel()
            {
                Id = entity.Id,
                CustomPizzaId = entity.CustomPizzaId,
                PizzaName = entity.Name,
                Size = entity.Size,
                PizzaImage = entity.PizzaImage,
                PizzaPrice = entity.Price + _repository.GetIngredientsPrice(entity.CustomPizzaId),
                Ingredients=_repository.GetListIngredients(entity.CustomPizzaId)?.Select(x => new IngredientViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Image = x.Image
                }
            ).ToList()
            });

            var finalPrice = 0;
            finalPrice = orderDetails.Select(x => x.Price).Sum();

            BasketViewModel basketModel = new BasketViewModel()
            {
               Orders = orderModel.ToList(),
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



