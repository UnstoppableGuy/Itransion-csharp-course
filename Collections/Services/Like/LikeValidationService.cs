using CollectionPR.Data.Interfaces;
using CollectionPR.Services.Interfaces;

namespace CollectionPR.Services.Classes;

public class LikeValidationService : ILikeValidation
{
    private readonly IUserRepository userRepository;
    private readonly ICollectionRepository collectionRepository;
    private readonly IItemRepository itemRepository;

    public LikeValidationService(IUserRepository userRepository, ICollectionRepository collectionRepository, IItemRepository itemRepository)
    {
        this.userRepository = userRepository;
        this.collectionRepository = collectionRepository;
        this.itemRepository = itemRepository;
    }

    public bool IsUserOwner(string userEmail, int collectionId)
    {
        return this.userRepository.GetSingleAsync(u => u.UserName == userEmail).Result!.Id ==
            this.collectionRepository.GetSingleAsync(c => c.Id == collectionId).Result!.AuthorId;
    }
}