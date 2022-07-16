using PizzaApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PizzaApp.Repository
{
    public class Repository : IRepository
    {
        public ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public int Id = 1;

        //Pizza
        public PizzaEntity AddPizza(PizzaEntity item)
        {
            if (item == null)
            {
                throw new NotImplementedException("item");
            }


            _context.Pizza.Add(item);
            _context.SaveChanges();
            return item;
        }

        public bool DeletePizza(PizzaEntity item)
        {
            _context.Pizza.Remove(item);
            _context.SaveChanges();
            return true;
        }

        public PizzaEntity GetPizza(int id)
        {
            var pizza = _context.Pizza.FirstOrDefault(d => d.PizzaID == id);
            return pizza;
        }

        public IEnumerable<PizzaEntity> GetAllPizzas()
        {
            var pizzas = _context.Pizza.ToList();
            return pizzas;
        }

        public bool UpdatePizza(PizzaEntity udItem, PizzaEntity item)
        {
            if (udItem == null)
            {
                throw new NotImplementedException();
            }

            var ud = _context.Pizza.Find(udItem);
            if (ud == null)
            {
                throw new NotImplementedException();
            }

            _context.Pizza.Remove(udItem);
            _context.Pizza.Add(item);
            _context.SaveChanges();
            return true;

        }

        //Price
        public PriceEntity AddPrice(PriceEntity price)
        {
            if (price == null)
            {
                throw new NotImplementedException();
            }

            _context.PizzaPrice.Add(price);
            _context.SaveChanges();
            return price;
        }

        public bool DeletePrice(PriceEntity price)
        {
            if (price == null)
            {
                throw new NotImplementedException();
            }

            _context.PizzaPrice.Remove(price);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<PriceEntity> GetAllPrices()
        {
            var prices = _context.PizzaPrice.ToList();
            return prices;
        }

        public PriceEntity GetPrice(int pizzaId, int sizeId)
        {
            var price = _context.PizzaPrice.FirstOrDefault(x => x.PizzaID == pizzaId && x.SizeID == sizeId);
            return price;
        }

        public bool UpdatePrice(PriceEntity oldPrice, PriceEntity newPrice)
        {
            if (newPrice == null)
            {
                throw new NotImplementedException();
            }

            var ud = _context.PizzaPrice.Find(oldPrice);
            if (ud == null)
            {
                throw new NotImplementedException();
            }

            _context.PizzaPrice.Remove(oldPrice);
            _context.PizzaPrice.Add(newPrice);
            _context.SaveChanges();
            return true;

        }

        //Order
        public OrderEntity AddOrder(OrderEntity order)
        {
            try
            {
                if (order == null)
                {
                    throw new NotImplementedException();
                }

                _context.Order.Add(order);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
            return order;
        }

        public bool DeleteOrder(OrderEntity order)
        {
            if (order == null)
            {
                throw new NotImplementedException();
            }

            try
            {
                _context.Order.Remove(order);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }

            return true;
        }

        public IEnumerable<OrderEntity> GetAllOrders()
        {
            var orders = _context.Order.ToList();
            return orders;
        }

        public OrderEntity GetOrder(int orderId)
        {
            var order = _context.Order.FirstOrDefault(x => x.Id == orderId);
            return order;
        }

        public bool UpdateOrder(OrderEntity oldOrder, OrderEntity newOrder)
        {
            if (newOrder == null)
            {
                throw new NotImplementedException();
            }

            var ud = _context.Order.Find(oldOrder);
            if (ud == null)
            {
                throw new NotImplementedException();
            }

            _context.Order.Remove(oldOrder);
            _context.Order.Add(newOrder);
            _context.SaveChanges();
            return true;
        }

        //Ingredients
        public IngredientEntity AddIngredient(IngredientEntity ingredient)
        {
            if (ingredient == null)
            {
                throw new NotImplementedException();
            }

            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
            return ingredient;
        }

        public bool DeleteIngredient(IngredientEntity ingredient)
        {
            if (ingredient == null)
            {
                throw new NotImplementedException();
            }

            _context.Ingredients.Remove(ingredient);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<IngredientEntity> GetAllIngredients()
        {
            var igredients = _context.Ingredients.ToList();
            return igredients;
        }

        public IngredientEntity GetIngredient(int ingredientId)
        {
            var ingerdient = _context.Ingredients.FirstOrDefault(x => x.Id == ingredientId);
            return ingerdient;
        }

        public bool UpdateIngredient(IngredientEntity oldIngredient, IngredientEntity newIngredient)
        {
            if (newIngredient == null)
            {
                throw new NotImplementedException();
            }

            var ud = _context.Ingredients.Find(oldIngredient);
            if (ud == null)
            {
                throw new NotImplementedException();
            }

            _context.Ingredients.Remove(oldIngredient);
            _context.Ingredients.Add(newIngredient);
            _context.SaveChanges();
            return true;
        }

        //Size
        public SizeEntity AddSize(SizeEntity size)
        {
            if (size == null)
            {
                throw new NotImplementedException();
            }

            _context.PizzaSize.Add(size);
            _context.SaveChanges();
            return size;
        }

        public bool DeleteSize(SizeEntity size)
        {
            if (size == null)
            {
                throw new NotImplementedException();
            }

            _context.PizzaSize.Remove(size);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<SizeEntity> GetAllSizes()
        {
            var sizes = _context.PizzaSize.ToList();
            return sizes;
        }

        public SizeEntity GetSize(int sizeId)
        {
            var size = _context.PizzaSize.FirstOrDefault(x => x.SizeID == sizeId);
            return size;
        }

        public SizeEntity GetSizeId(string sizeString)
        {
            var size = _context.PizzaSize.FirstOrDefault(x => x.Size == sizeString);
            return size;
        }

        public bool UpdateSize(SizeEntity oldSize, SizeEntity newSize)
        {
            if (newSize == null)
            {
                throw new NotImplementedException();
            }

            var ud = _context.PizzaSize.Find(oldSize);
            if (ud == null)
            {
                throw new NotImplementedException();
            }

            _context.PizzaSize.Remove(oldSize);
            _context.PizzaSize.Add(newSize);
            _context.SaveChanges();
            return true;
        }


        //CustomPizzaInfredients
        public CustomPizzaIngredientsEntity AddCustomPizza(CustomPizzaIngredientsEntity customPizza)
        {
            try
            {
                if (customPizza == null)
                {
                    throw new NotImplementedException();
                }

                _context.CustomPizzaIngredients.Add(customPizza);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
            return customPizza;
        }

        public bool DeleteCustomPizza(CustomPizzaIngredientsEntity customPizza)
        {
            if (customPizza == null)
            {
                throw new NotImplementedException();
            }

            try
            {
                _context.CustomPizzaIngredients.Remove(customPizza);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }

            return true;
        }

        public IEnumerable<CustomPizzaIngredientsEntity> GetAllCustomPizzas()
        {
            var customPizzas = _context.CustomPizzaIngredients.ToList();
            return customPizzas;
        }

        public CustomPizzaIngredientsEntity GetCustomPizza(string customPizzaId)
        {
            var customPizza = _context.CustomPizzaIngredients.FirstOrDefault(x => x.CustomPizzaId == customPizzaId);
            return customPizza;
        }

        public bool UpdateCustomPizza(CustomPizzaIngredientsEntity oldCustomPizza, CustomPizzaIngredientsEntity newCustomPizza)
        {
            if (newCustomPizza == null)
            {
                throw new NotImplementedException();
            }

            var ud = _context.CustomPizzaIngredients.Find(oldCustomPizza);
            if (ud == null)
            {
                throw new NotImplementedException();
            }

            _context.CustomPizzaIngredients.Remove(oldCustomPizza);
            _context.CustomPizzaIngredients.Add(newCustomPizza);
            _context.SaveChanges();
            return true;
        }

        public int GetIngredientsPrice(string customPizzaId)
        {
            var customPizzas = _context.CustomPizzaIngredients.ToList();
            int SumIngredientsPrice = 0;
            foreach (var item in customPizzas)
            {
                if (item.CustomPizzaId == customPizzaId)
                {
                    var ingredientId = item.IngredientId;
                    var indredientPrice = _context.Ingredients.FirstOrDefault(x => x.Id == ingredientId).Price;
                    SumIngredientsPrice += indredientPrice;
                }
            }
            return SumIngredientsPrice;
        }

        public List<IngredientEntity> GetListIngredients(string customPizzaId)
        {
            var customPizzas = _context.CustomPizzaIngredients.ToList();
            List<IngredientEntity> ingredients = new List<IngredientEntity>();
            foreach (var item in customPizzas)
            {
                if (item.CustomPizzaId == customPizzaId)
                {
                    var indredientId = item.IngredientId;
                    IngredientEntity ingredient = GetIngredient(indredientId);
                    ingredients.Add(ingredient);

                }
            }
            return ingredients;
        }


        public List<OrderDetailsEntity> GetOrderDetails()
        {
            var orderDetails = _context.Order
                .Join(
                _context.Pizza,
                order => order.PizzaId,
                pizza => pizza.PizzaID,
                (order, pizza) => new
                {
                    Id = order.Id,
                    PizzaId = pizza.PizzaID,
                    CustomPizzaId = order.CustomPizzaId,
                    Name = pizza.PizzaName,
                    PizzaImage = pizza.ImageFile,
                    SizeId = order.SizeId
                }
                )
                .Join(
                _context.PizzaSize,
                order => order.SizeId,
                size => size.SizeID,
                (order, size) => new
                {
                    Id = order.Id,
                    PizzaId = order.PizzaId,
                    CustomPizzaId = order.CustomPizzaId,
                    Name = order.Name,
                    PizzaImage = order.PizzaImage,
                    Size = size.Size,
                    SizeID = order.SizeId
                }
                )
                .Join(
                _context.PizzaPrice,
                order => new { x1 = order.PizzaId, x2 = order.SizeID },
                price => new { x1 = price.PizzaID, x2 = price.SizeID },
                (order, price) => new OrderDetailsEntity()
                {
                    Id = order.Id,
                    PizzaId = order.PizzaId,
                    CustomPizzaId = order.CustomPizzaId,
                    Name = order.Name,
                    PizzaImage = order.PizzaImage,
                    Size = order.Size,
                    //Price = price.Price + GetIngredientsPrice(order.CustomPizzaId),
                    Price = price.Price,
                    //Ingredients = GetListIngredients(order.CustomPizzaId)
                }
                ).ToList();

            return orderDetails;

           
        }

    }
}

