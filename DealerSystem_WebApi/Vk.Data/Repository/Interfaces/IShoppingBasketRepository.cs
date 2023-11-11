using DataLayer.Model;

namespace DataLayer.Repository.Interfaces;

public interface IShoppingBasketRepository : IGenericRepository<ShoppingBasket>
{
    List<ShoppingBasket> GetUserBaskets(int userId, params string[] includes);
    List<ShoppingBasket> GetOrderBaskets(int orderId, params string[] includes);
    List<ShoppingBasket> GetProductBaskets(int productId, params string[] includes);
}
