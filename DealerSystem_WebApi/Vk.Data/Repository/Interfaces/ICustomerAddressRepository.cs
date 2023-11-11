using DataLayer.Model;

namespace DataLayer.Repository.Interfaces;

public interface ICustomerAddressRepository : IGenericRepository<CustomerAddress>
{

    List<CustomerAddress> GetUserAddresses(int userId, params string[] includes);

}
