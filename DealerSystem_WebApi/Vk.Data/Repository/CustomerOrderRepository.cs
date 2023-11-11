using DataLayer.Context;
using DataLayer.Model;
using DataLayer.Repository.Interfaces;
using System.Data.Entity;


namespace DataLayer.Repository;

public class CustomerOrderRepository : GenericRepository<CustomerOrder>, ICustomerOrderRepository
{
    public CustomerOrderRepository(VkDbContext dbContext) : base(dbContext)
    {
    }

    public List<CustomerOrder> GetUserOrders(int userId, params string[] includes)
    {
        var query = dbContext.Set<CustomerOrder>().AsQueryable();
        if (includes.Any())
        {
            query = includes.Aggregate(query, (current, incl) => current.Include(incl));
        }
        return query.Where(x => x.UserId == userId).ToList();
    }
}
