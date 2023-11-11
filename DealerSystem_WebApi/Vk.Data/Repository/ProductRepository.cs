using DataLayer.Context;
using DataLayer.Model;
using DataLayer.Repository.Interfaces;
using System.Data.Entity;


namespace DataLayer.Repository;

public class ProductRepository:GenericRepository<Product> , IProductRepository
{
    public ProductRepository(VkDbContext dbContext) : base(dbContext)
    {

    }
}
