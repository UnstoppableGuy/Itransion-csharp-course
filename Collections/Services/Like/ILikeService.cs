using CollectionPR.Models;

namespace CollectionPR.Services.Interfaces;

public interface ILikeService
{
    List<Like> GetLikesByItemId(int id);
    void AddLike(Like like);
    void DeleteLike(Like like);
    Like? IsLikeExists(string userId, int itemId);
}