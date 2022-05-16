using CollectionPR.Data.Interfaces;
using CollectionPR.Services.Interfaces;

namespace CollectionPR.Services.Classes;

public class CollectionValidationService : ICollectionValidation
{
    private readonly ICollectionRepository collectionRepository;

    public CollectionValidationService(ICollectionRepository collectionRepository)
    {
        this.collectionRepository = collectionRepository;
    }

    public bool IsCollectionNull(int collectionId)
    {
        var collection = this.collectionRepository.GetSingleAsync(c => c.Id == collectionId).Result;

        return collection == null;
    }
}