using DataLayer.Context;
using DataLayer.Model;
using DataLayer.Repository.Interfaces;
using System.Data.Entity;


namespace DataLayer.Repository;

public class ShoppingBasketRepository : GenericRepository<ShoppingBasket>, IShoppingBasketRepository
{
    public ShoppingBasketRepository(VkDbContext dbContext) : base(dbContext)
    {
    }

    public List<ShoppingBasket> GetOrderBaskets(int orderId, params string[] includes)
    {
        var query = dbContext.Set<ShoppingBasket>().AsQueryable();
        if (includes.Any())
        {
            query = includes.Aggregate(query, (current, incl) => current.Include(incl));
        }
        return query.Where(x => x.OrderId == orderId).ToList();
    }

    public List<ShoppingBasket> GetProductBaskets(int productId, params string[] includes)
    {
        var query = dbContext.Set<ShoppingBasket>().AsQueryable();
        if (includes.Any())
        {
            query = includes.Aggregate(query, (current, incl) => current.Include(incl));
        }
        return query.Where(x => x.ProductId == productId).ToList();
    }

    public List<ShoppingBasket> GetUserBaskets(int userId, params string[] includes)
    {
        var query = dbContext.Set<ShoppingBasket>().AsQueryable();
        if (includes.Any())
        {
            query = includes.Aggregate(query, (current, incl) => current.Include(incl));
        }
        return query.Where(x => x.UserId == userId).ToList();
    }
}
