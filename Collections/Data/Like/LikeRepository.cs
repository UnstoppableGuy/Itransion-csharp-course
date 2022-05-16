using CollectionPR.Data.Interfaces;
using CollectionPR.Models;

namespace CollectionPR.Data.Repositories;

public class LikeRepository : AbstractRepository<Like>, ILikeRepository
{
    public LikeRepository(CollectionDbContext context) : base(context)
    {
    }
}