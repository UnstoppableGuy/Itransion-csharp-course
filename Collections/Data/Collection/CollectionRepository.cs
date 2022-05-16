using CollectionPR.Data.Interfaces;
using CollectionPR.Models;

namespace CollectionPR.Data.Repositories;

public class CollectionRepository : AbstractRepository<Collection>, ICollectionRepository
{
    public CollectionRepository(CollectionDbContext context) : base(context)
    {
    }
}