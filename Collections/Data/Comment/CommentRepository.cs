using CollectionPR.Data.Interfaces;
using CollectionPR.Models;

namespace CollectionPR.Data.Repositories;

public class CommentRepository : AbstractRepository<Comment>, ICommentRepository
{
    public CommentRepository(CollectionDbContext context) : base(context)
    {
    }
}