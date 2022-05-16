using CollectionPR.Data.Interfaces;
using CollectionPR.Models;

namespace CollectionPR.Data.Repositories;

public class ItemRepository : AbstractRepository<Item>, IItemRepository
{
    public ItemRepository(CollectionDbContext context) : base(context)
    {
    }
}