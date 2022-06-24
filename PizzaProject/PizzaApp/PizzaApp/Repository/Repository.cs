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
            if (order == null)
            {
                throw new NotImplementedException();
            }

            _context.Order.Add(order);
            _context.SaveChanges();
            return order;
        }

        public bool DeleteOrder(OrderEntity order)
        {
            if (order == null)
            {
                throw new NotImplementedException();
            }

            _context.Order.Remove(order);
            _context.SaveChanges();
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


        //SizePrice
        public SizesPricesEntity AddPriceSize(SizesPricesEntity sizePrice)
        {
            if (sizePrice == null)
            {
                throw new NotImplementedException();
            }

            _context.SizePrice.Add(sizePrice);
            _context.SaveChanges();
            return sizePrice;
        }

        public bool DeletePriceSize(SizesPricesEntity sizePrice)
        {
            if (sizePrice == null)
            {
                throw new NotImplementedException();
            }

            _context.SizePrice.Remove(sizePrice);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<SizesPricesEntity> GetAllSizesPrices()
        {
            var sizesPrices = _context.SizePrice.ToList();
            return sizesPrices;
        }

        public SizesPricesEntity GetPriceBySize(string size)
        {
            var price = _context.SizePrice.FirstOrDefault(x => x.Size == size);
            return price;
        }

        
        public bool UpdatePriceSize(SizesPricesEntity oldSizePrice, SizesPricesEntity newSizePrice)
        {
            if (newSizePrice == null)
            {
                throw new NotImplementedException();
            }

            var ud = _context.SizePrice.Find(oldSizePrice);
            if (ud == null)
            {
                throw new NotImplementedException();
            }

            _context.SizePrice.Remove(oldSizePrice);
            _context.SizePrice.Add(newSizePrice);
            _context.SaveChanges();
            return true;
        }

        //CustomerData
        public CustomerDataEntity AddCustomerData(CustomerDataEntity customerData)
        {
            if (customerData == null)
            {
                throw new NotImplementedException();
            }

            _context.CustomerData.Add(customerData);
            _context.SaveChanges();
            return customerData;
        }

        public bool DeleteCustomerData(CustomerDataEntity customerData)
        {
            if (customerData == null)
            {
                throw new NotImplementedException();
            }

            _context.CustomerData.Remove(customerData);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<CustomerDataEntity> GetAllCustomersData()
        {
            var customersData = _context.CustomerData.ToList();
            return customersData;
        }

        public CustomerDataEntity GetCustomerData(int id)
        {
            var customer = _context.CustomerData.FirstOrDefault(x => x.Id == id);
            return customer;
        }


        public bool UpdateCustomerData(CustomerDataEntity oldCustomerData, CustomerDataEntity newCustomerData)
        {
            if (newCustomerData == null)
            {
                throw new NotImplementedException();
            }

            var ud = _context.CustomerData.Find(oldCustomerData);
            if (ud == null)
            {
                throw new NotImplementedException();
            }

            _context.CustomerData.Remove(oldCustomerData);
            _context.CustomerData.Add(newCustomerData);
            _context.SaveChanges();
            return true;
        }
    }
}

       