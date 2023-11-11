using DataLayer.Context;
using DataLayer.Repository;
using DataLayer.Repository.Interfaces;
using Serilog;


namespace DataLayer.Uow;

public class UnitOfWork : IUnitOfWork
{

    private readonly VkDbContext dbContext;

    public UnitOfWork(VkDbContext dbContext)
    {
        this.dbContext = dbContext;

        ProductRepository = new ProductRepository(dbContext);
        CustomerOrderRepository = new CustomerOrderRepository(dbContext);
        UserRepository = new UserRepository(dbContext);
        CustomerAddressRepository = new CustomerAddressRepository(dbContext);
        ShoppingBasketRepository = new ShoppingBasketRepository(dbContext);

    }

    public IProductRepository ProductRepository { get; private set; }

    public ICustomerOrderRepository CustomerOrderRepository { get; private set; }

    public IUserRepository UserRepository { get; private set; }

    public ICustomerAddressRepository CustomerAddressRepository { get; private set; }

    public IShoppingBasketRepository ShoppingBasketRepository { get; private set; }

    public void Complete()
    {
        dbContext.SaveChanges();
    }

    public void CompleteTransaction()
    {
        using (var transaction = dbContext.Database.BeginTransaction())
        {
            try
            {
                dbContext.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.Error("CompleteTransaction", ex);
            }
        }
    }

}