using CollectionPR.Models;
using CollectionPR.Services.Classes;

namespace CollectionPR.Services.Interfaces;

public interface IItemService
{
    List<Item> GetItemsByCollectionId(int id);
    Item GetItemById(int id);
    void DeleteItem(Item item);
    ValueTask AddItem(Item item);
    ValueTask Save();
    List<Item> FullTextSearch(string searchString);
    List<Item> GetAll();
}