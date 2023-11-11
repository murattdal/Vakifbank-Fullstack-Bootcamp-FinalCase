using DataLayer.Repository.Interfaces;

namespace DataLayer.Uow;

public interface IUnitOfWork
{
    void Complete();
    void CompleteTransaction();

    IProductRepository ProductRepository { get; }
    ICustomerOrderRepository CustomerOrderRepository { get; }
    IUserRepository UserRepository { get; }
    ICustomerAddressRepository CustomerAddressRepository { get; }
    IShoppingBasketRepository ShoppingBasketRepository { get; }




}