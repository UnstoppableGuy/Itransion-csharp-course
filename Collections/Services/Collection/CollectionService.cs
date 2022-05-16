using CollectionPR.Data.Interfaces;
using CollectionPR.Models;
using CollectionPR.Services.Interfaces;

namespace CollectionPR.Services.Classes;

public class CollectionService : ICollectionService
{
    private readonly ICollectionRepository collectionRepository;

    public CollectionService(ICollectionRepository collectionRepository)
    {
        this.collectionRepository = collectionRepository;
    }

    public List<Collection> GetCollectionsByUserId(string userId)
    {
        return this.collectionRepository.FindBy(i => i.AuthorId == userId).ToList();
    }

    public void DeleteCollection(Collection objectToDelete)
    {
        this.collectionRepository.Delete(objectToDelete);
        this.collectionRepository.Commit();
    }
    
    public Collection GetCollectionByItemId(int id)
    {
        return this.collectionRepository.GetSingle(c => c.Id == id)!;
    }

    public Collection GetCollectionByItemIdAsync(int id)
    {
        return this.collectionRepository.GetSingleAsync(c => c.Id == id).GetAwaiter().GetResult()!;
    }

    public void AddCollection(Collection collection)
    {
        this.collectionRepository.Add(collection);
        this.collectionRepository.Commit();
    }

    public Collection GetCollectionById(int id)
    {
        return this.collectionRepository.FindAsync(id).GetAwaiter().GetResult()!;
    }

    public async ValueTask Save()
    {
        await this.collectionRepository.CommitAsync();
    }

    public List<Collection> GetAll()
    {
        return this.collectionRepository.GetAll().ToList();
    }
}