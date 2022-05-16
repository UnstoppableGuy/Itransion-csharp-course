using CollectionPR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CollectionPR.Controllers;

public class DeleteContentController : Controller
{
    private readonly IDeleteCloud DeleteFromCloud;
    private readonly ICollectionService collectionService;
    private readonly IItemService itemService;

    public DeleteContentController(IDeleteCloud DeleteFromCloud, ICollectionService collectionService, IItemService itemService)
    {
        this.DeleteFromCloud = DeleteFromCloud;
        this.collectionService = collectionService;
        this.itemService = itemService;
    }
    
    [Route("/Home/ViewItem/{collectionId:int}/DeleteCollection")]
    public async Task<IActionResult> DeleteCollection(int collectionId)
    {
        var objectToDelete = this.collectionService.GetCollectionById(collectionId);

        var itemsToDelete = this.itemService.GetItemsByCollectionId(collectionId);

        foreach (var item in itemsToDelete)
        {
            if (item.FileName != "")
            {
                this.DeleteFromCloud.DeleteFromCloud(item.FileName);
            }
            
            this.itemService.DeleteItem(item);
        }

        if (objectToDelete.FileName != "")
        {
            this.DeleteFromCloud.DeleteFromCloud(objectToDelete.FileName);
        }
        
        this.collectionService.DeleteCollection(objectToDelete);

        return await Task.Run(() => RedirectToAction("Profile", "Home"));
    }
    
    [Route("/Home/ViewItem/{collectionId:int}/{itemId:int}/DeleteItem")]
    public async Task<IActionResult> DeleteItem(int itemId, int collectionId)
    {
        var objectToDelete = this.itemService.GetItemById(itemId);
        
        if (objectToDelete.FileName != "")
        {
            this.DeleteFromCloud.DeleteFromCloud(objectToDelete.FileName);
        }
        
        this.itemService.DeleteItem(objectToDelete);

        return await Task.Run(() => Redirect($"/Home/ViewCollection/{collectionId}"));
    }
}