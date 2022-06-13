using PizzaApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.Repository
{
    public interface IRepository
    {
        IEnumerable<PizzaEntity> GetAllPizzas();
        PizzaEntity GetPizza(int id);
        PizzaEntity AddPizza(PizzaEntity item);
        bool UpdatePizza(PizzaEntity uditem, PizzaEntity item);
        bool DeletePizza(PizzaEntity item);

        IEnumerable<PriceEntity> GetAllPrices();
        PriceEntity GetPrice(int pizzaId, int sizeId);
        PriceEntity AddPrice(PriceEntity price);
        bool DeletePrice(PriceEntity price);
        bool UpdatePrice(PriceEntity oldPrice, PriceEntity newPrice);

        IEnumerable<OrderEntity> GetAllOrders();
        OrderEntity GetOrder(int orderId);
        OrderEntity AddOrder(OrderEntity order);
        bool DeleteOrder(OrderEntity order);
        bool UpdateOrder(OrderEntity oldOrder, OrderEntity newOrder);
    }
}
