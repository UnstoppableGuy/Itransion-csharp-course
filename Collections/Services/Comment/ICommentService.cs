using CollectionPR.Models;

namespace CollectionPR.Services.Interfaces;

public interface ICommentService
{
    Task AddComment(Comment comment);
    int GetCommentIdByText(Comment comment);
    List<Comment> GetAllComments();
    List<Comment> GetCommentsInItem(int itemId);
}