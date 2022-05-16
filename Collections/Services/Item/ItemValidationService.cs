using CollectionPR.Data.Interfaces;
using CollectionPR.Services.Interfaces;

namespace CollectionPR.Services.Classes;

public class ItemValidationService : IItemValidation
{
    private readonly IItemRepository itemRepository;

    public ItemValidationService(IItemRepository itemRepository)
    {
        this.itemRepository = itemRepository;
    }

    public bool IsItemNull(int itemId)
    {
        var item = this.itemRepository.GetSingleAsync(i => i.Id == itemId).Result;

        return item == null;
    }
}