using DataLayer.Model;

namespace DataLayer.Repository.Interfaces;

public interface ICustomerOrderRepository : IGenericRepository<CustomerOrder>
{
    List<CustomerOrder> GetUserOrders(int userId, params string[] includes);
}
