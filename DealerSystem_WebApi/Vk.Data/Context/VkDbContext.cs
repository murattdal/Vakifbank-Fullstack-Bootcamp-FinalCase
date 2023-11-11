using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context;

public class VkDbContext : DbContext
{
    public VkDbContext(DbContextOptions<VkDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerOrderConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerAddressConfiguration());
        modelBuilder.ApplyConfiguration(new ShoppingBasketConfiguration());

        base.OnModelCreating(modelBuilder);
    }

}
