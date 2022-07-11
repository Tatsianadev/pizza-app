using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaApp.Models;
using PizzaApp.Repository;

namespace PizzaApp.Controllers
{
    public class CreatePizzaController : Controller
    {
        public IRepository _repository;
        public CreatePizzaController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: CreatePizza
        public ActionResult CreatePizza()
        {
            var sizesPricesEntity = _repository.GetAllSizesPrices();
            var sizePrice = sizesPricesEntity.Select(entity => new SizesPrizesViewModel()
            {
                Id = entity.Id,
                Size = entity.Size,
                Price=entity.Price
            }).ToList();

            var ingredientsEntity = _repository.GetAllIngredients();
            var ingredients = ingredientsEntity.Select(entity => new IngredientViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Image = entity.Image,
                
            }).ToList();

            //var dictionaryIngredients = new Dictionary<IngredientViewModel, bool>();
            //foreach (var ingredient in ingredients)
            //{
            //    dictionaryIngredients.Add(ingredient, false);
            //}
            
            

            CreatePizzaViewModel createModel = new CreatePizzaViewModel()
            {
                SizePrice = sizePrice,
                Ingredients = ingredients,
                FinalPrice=sizePrice.FirstOrDefault(x=>x.Size=="small").Price
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
                        // totalPrice += dataIngredient.Price;
                        var selectedIngredient = new IngredientViewModel()
                        {
                            Id = dataIngredient.Id,
                            Name = dataIngredient.Name,
                            Image = dataIngredient.Image
                        };

                        selectedIngredients.Add(selectedIngredient);
                    }
                }

                var createdPizzaImage = ConfigurationManager.AppSettings["CreatedPizzaImage"];
                var customerPizza = new OrderViewModel()
                {
                    Id = ++(_repository.GetAllOrders().Last().Id),
                    //PizzaId = ++(_repository.GetAllPizzas().Last().PizzaID) + (_repository.GetAllOrders().Last().Id),
                    PizzaName = createdPizza.Name,
                    //PizzaImage = "Bismarck.jpg",
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