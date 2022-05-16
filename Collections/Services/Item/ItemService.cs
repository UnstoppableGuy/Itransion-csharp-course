using HigLabo.Core;
using CollectionPR.Data.Interfaces;
using CollectionPR.Models;
using CollectionPR.Services.Interfaces;

namespace CollectionPR.Services.Classes;

public class ItemService : IItemService
{
    private readonly IItemRepository itemRepository;
    private readonly ICollectionRepository collectionRepository;

    public ItemService(IItemRepository itemRepository, ICollectionRepository collectionRepository)
    {
        this.itemRepository = itemRepository;
        this.collectionRepository = collectionRepository;
    }

    public List<Item> GetItemsByCollectionId(int id)
    {
        return this.itemRepository.FindBy(i => i.CollectionId == id).ToList();
    }

    public Item GetItemById(int id)
    {
        return this.itemRepository.FindAsync(id).GetAwaiter().GetResult()!;
    }

    public void DeleteItem(Item item)
    {
        this.itemRepository.Delete(item);
        this.itemRepository.Commit();
    }

    public async ValueTask AddItem(Item item)
    {
        await this.itemRepository.AddAsync(item);
        await this.itemRepository.CommitAsync();
    }

    public async ValueTask Save()
    {
        await this.itemRepository.CommitAsync();
    }

    public List<Item> FullTextSearch(string searchString)
    {
        var resultItems = new List<Item>();

        if (searchString.IsNullOrEmpty()) return resultItems;
        
        resultItems = this.itemRepository.FullTextSearch(searchString).ToList();

        var itemsInCollection = this.collectionRepository.FullTextSearch(searchString).ToList();

        foreach (var collection in itemsInCollection)
        {
            collection.CollectionItems = this.itemRepository.FindBy(c => c.CollectionId == collection.Id).ToList();

            foreach (var item in collection.CollectionItems!.Where(item =>
                         !resultItems.Contains(item)))
            {
                resultItems.Add(item);
            }
        }

        return resultItems;
    }

    public List<Item> GetAll()
    {
        return this.itemRepository.GetAll().ToList();
    }
}