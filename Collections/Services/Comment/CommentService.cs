using CollectionPR.Data.Interfaces;
using CollectionPR.Models;
using CollectionPR.Services.Interfaces;

namespace CollectionPR.Services.Classes;

public class CommentService : ICommentService
{
    private readonly ICommentRepository commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        this.commentRepository = commentRepository;
    }

    public async Task AddComment(Comment comment)
    {
        await this.commentRepository.AddAsync(comment);
        await this.commentRepository.CommitAsync();
    }

    public int GetCommentIdByText(Comment comment)
    {
        var commentId = this.commentRepository.GetSingle(c => c.CommentText == comment.CommentText)!.ItemId;
        return commentId;
    }

    public List<Comment> GetAllComments()
    {
        return this.commentRepository.GetAll().ToList();
    }

    public List<Comment> GetCommentsInItem(int itemId)
    {
        return this.commentRepository.FindBy(c => c.ItemId == itemId).ToList();
    }
}