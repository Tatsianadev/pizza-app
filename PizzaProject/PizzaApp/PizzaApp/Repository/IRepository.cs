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

        IEnumerable<IngredientEntity> GetAllIngredients();
        IngredientEntity GetIngredient(int ingredientId);
        IngredientEntity AddIngredient(IngredientEntity ingredient);
        bool DeleteIngredient(IngredientEntity ingredient);
        bool UpdateIngredient(IngredientEntity oldIngredient, IngredientEntity newIngredient);

        IEnumerable<SizeEntity> GetAllSizes();
        SizeEntity GetSize(int sizeId);
        SizeEntity GetSizeId(string sizeString);
        SizeEntity AddSize(SizeEntity size);
        bool DeleteSize(SizeEntity size);
        bool UpdateSize(SizeEntity oldSize, SizeEntity newSize);

        IEnumerable<SizesPricesEntity> GetAllSizesPrices();
        SizesPricesEntity GetPriceBySize(string size);
        SizesPricesEntity AddPriceSize(SizesPricesEntity sizePrice);
        bool DeletePriceSize(SizesPricesEntity sizePrice);
        bool UpdatePriceSize(SizesPricesEntity oldSizePrice, SizesPricesEntity newSizePrice);
    }
}
