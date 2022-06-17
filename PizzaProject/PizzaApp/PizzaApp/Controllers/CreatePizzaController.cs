using System;
using System.Collections.Generic;
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
            var sizesEntity = _repository.GetAllSizes();
            var sizes = sizesEntity.Select(entity => new SizeViewModel()
            {
                SizeID = entity.SizeID,
                Size = entity.Size
            });

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
                Size = sizes.ToList(),
                Ingredients = ingredients
            };
            
            
            return View(createModel);
        }

        [HttpPost]
        public ActionResult CreatedPizza(CreatePizzaViewModel createdPizza)
        {
            var totalPrice = 3;

            if (createdPizza.SelectedSize=="medium")
            {
                totalPrice += 1;
            }
            if (createdPizza.SelectedSize == "big")
            {
                totalPrice += 2;
            }

            var selectedIngredients=new List<IngredientViewModel>();

            foreach (var ingredient in createdPizza.Ingredients)
            {
                if (ingredient.Ticked == true)
                {
                    var dataIngredient = _repository.GetIngredient(ingredient.Id);
                    totalPrice += dataIngredient.Price;
                    var selectedIngredient=new IngredientViewModel()
                    {
                        Id=dataIngredient.Id,
                        Name = dataIngredient.Name,
                        Image = dataIngredient.Image
                    };
                   
                   selectedIngredients.Add(selectedIngredient);
                }
            }

            var customerPizza = new OrderViewModel()
            {
                Id = (_repository.GetAllOrders().Last().Id) + 1,
                PizzaId = (_repository.GetAllPizzas().Last().PizzaID) + 1,
                PizzaName = createdPizza.Name,
                PizzaImage = "Bismarck.jpg",
                Size = createdPizza.SelectedSize,
                PizzaPrice = totalPrice,
                Ingredients = selectedIngredients
            };

            return View(customerPizza);
        }
    }
}