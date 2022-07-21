using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaApp.Models;
using PizzaApp.Repository;
using PizzaApp.Repository.Entities;

namespace PizzaApp.Controllers
{
    public class CreatePizzaController : Controller
    {
        public IRepository _repository;
        public CreatePizzaController(IRepository repository)
        {
            _repository = repository;
        }

      

        public ActionResult CreatePizza()
        {
            var sizesEntity = _repository.GetAllSizes();
            var sizes = sizesEntity.Select(entity => new SizeViewModel()
            {
                SizeID = entity.SizeID,
                Size = entity.Size
            });

            var defaultPrices = _repository.GetAllPrices();
            var prices = defaultPrices.Select(entity => new PriceViewModel()
            {
                PriceID = entity.PriceID,
                PizzaID = entity.PizzaID,
                SizeID = entity.SizeID
            });

            var ingredientsEntity = _repository.GetAllIngredients();
            var ingredients = ingredientsEntity.Select(entity => new IngredientViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Image = entity.Image,

            }).ToList();

            CreatePizzaViewModel createModel = new CreatePizzaViewModel()
            {
                Sizes = sizes,
                DefaultPrices = prices,
                Ingredients = ingredients,
                FinalPrice = prices.FirstOrDefault(x => x.SizeID == 1).Price
            };

            return View(createModel);
        }





        [HttpPost]
        public ActionResult CreatedPizza(CreatePizzaViewModel createdPizza)
        {
            if (ModelState.IsValid)
            {

                var totalPrice = createdPizza.FinalPrice;

                var selectedIngredients = new List<IngredientViewModel>();

                foreach (var ingredient in createdPizza.Ingredients)
                {
                    if (ingredient.Ticked == true)
                    {
                        var dataIngredient = _repository.GetIngredient(ingredient.Id);
                        var selectedIngredient = new IngredientViewModel()
                        {
                            Id = dataIngredient.Id,
                            Name = dataIngredient.Name,
                            Image = dataIngredient.Image
                        };

                        selectedIngredients.Add(selectedIngredient);
                    }
                }

                string g = Guid.NewGuid().ToString();

                var createdPizzaImage = ConfigurationManager.AppSettings["CreatedPizzaImage"];
                var customerPizza = new OrderViewModel()
                {
                    CustomPizzaId = g,
                    PizzaName = createdPizza.Name,
                    PizzaImage = createdPizzaImage,
                    Size = createdPizza.SelectedSize,
                    PizzaPrice = totalPrice,
                    Ingredients = selectedIngredients
                };

                return View(customerPizza);
            }
            return View("CreatePizza");
        }

        
    }
}