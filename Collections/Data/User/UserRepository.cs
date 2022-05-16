using CollectionPR.Data.Interfaces;
using CollectionPR.Models;

namespace CollectionPR.Data.Repositories;

public class UserRepository : AbstractRepository<User>, IUserRepository
{
    public UserRepository(CollectionDbContext context) : base(context)
    {
    }
}