namespace CollectionPR.Services.Interfaces;

public interface ILikeValidation
{
    bool IsUserOwner(string userEmail, int collectionId);
}