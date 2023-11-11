using DataLayer.Context;
using DataLayer.Model;
using DataLayer.Repository.Interfaces;
using System.Data.Entity;

namespace DataLayer.Repository;

public class UserRepository: GenericRepository<User>, IUserRepository
{
    public UserRepository(VkDbContext dbContext) : base(dbContext)
    {

    }
}
