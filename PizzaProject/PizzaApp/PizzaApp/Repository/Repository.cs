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
    }
}

       