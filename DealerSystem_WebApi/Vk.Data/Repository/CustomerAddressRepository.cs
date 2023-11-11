using DataLayer.Context;
using DataLayer.Model;
using DataLayer.Repository.Interfaces;
using System.Data.Entity;


namespace DataLayer.Repository;

public class CustomerAddressRepository : GenericRepository<CustomerAddress>, ICustomerAddressRepository
{
    public CustomerAddressRepository(VkDbContext dbContext) : base(dbContext)
    {
    }



    public List<CustomerAddress> GetUserAddresses(int userId, params string[] includes)
    {
        var query = dbContext.Set<CustomerAddress>().AsQueryable();
        if (includes.Any())
        {
            query = includes.Aggregate(query, (current, incl) => current.Include(incl));
        }
        return query.Where(x => x.UserId == userId).ToList();
    }



}
