using Microsoft.AspNetCore.Mvc;
using CollectionPR.Services;
using CollectionPR.Services.Interfaces;
using CollectionPR.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CollectionPR.Controllers;

public class EditController : Controller
{
    private readonly ISaveFileAsync saveFileAsync;
    private readonly IDeleteCloud DeleteFromCloud;
    private readonly ICollectionService collectionService;
    private readonly IItemService itemService;

    public EditController(ISaveFileAsync saveFileAsync, IDeleteCloud DeleteFromCloud, ICollectionService collectionService, IItemService itemService)
    {
        this.saveFileAsync = saveFileAsync;
        this.DeleteFromCloud = DeleteFromCloud;
        this.collectionService = collectionService;
        this.itemService = itemService;
    }
    
    [Authorize]
    [HttpGet]
    [Route("/Home/EditCollection/{collectionId:int}")]
    public IActionResult EditView(int collectionId)
    {
        ViewBag.collectionId = collectionId;
        
        return View("EditCollection");
    }
    
    [Authorize]
    [HttpPost]
    [Route("/Home/EditCollection/{collectionId:int}")]
    public async Task<IActionResult> EditCollection(EditCollectionViewModel editCollectionViewModel, int collectionId)
    {
        if (!ModelState.IsValid) return await Task.Run(() => View(editCollectionViewModel));
        
        var editingCollection = this.collectionService.GetCollectionById(collectionId);

        var resultingString = "";

        if (Request.Form.Files.Count != 0)
        {
            var file = Request.Form.Files[0];
            resultingString = this.saveFileAsync.SaveFileAsync(file).Result;
        }

        editingCollection.Title = editCollectionViewModel.Title;
        editingCollection.Description = editCollectionViewModel.Description;
        
        if (Request.Form.Files.Count != 0 && editingCollection.FileName != "" || 
            Request.Form.Files.Count == 0 && editingCollection.FileName != "" && editCollectionViewModel.DeleteImage == "true")
        {
            this.DeleteFromCloud.DeleteFromCloud(editingCollection.FileName);
            editingCollection.FileName = resultingString;
        }
        else if (Request.Form.Files.Count != 0 && editingCollection.FileName == "")
        {
            editingCollection.FileName = resultingString;
        }
        
        await this.collectionService.Save();

        return await Task.Run(() => RedirectToAction("ViewCollection", "Home", editCollectionViewModel));
    }
    
    [HttpGet]
    [Route("/Home/EditItem/{collectionId:int}/{itemId:int}")]
    public IActionResult EditItem(int collectionId, int itemId)
    {
        ViewBag.collectionId = collectionId;
        ViewBag.itemId = itemId;

        return View("EditItem");
    }
    
    [Authorize]
    [HttpPost]
    [Route("/Home/EditItem/{collectionId:int}/{itemId:int}")]
    public async Task<IActionResult> EditItem(EditItemViewModel editItemViewModel, int collectionId, int itemId)
    {
        ViewBag.collectionId = collectionId;
        
        if (!ModelState.IsValid) return await Task.Run(() => View(editItemViewModel));

        var editingItem = this.itemService.GetItemById(itemId);
        
        var resultingString = "";
        if (Request.Form.Files.Count != 0)
        {
            var file = Request.Form.Files[0];
            resultingString = this.saveFileAsync.SaveFileAsync(file).Result;
        }

        editingItem.Title = editItemViewModel.Title;
        editingItem.Description = editItemViewModel.Description;
        editingItem.Date = editItemViewModel.Date;
        editingItem.Brand = editItemViewModel.Brand;

        if (Request.Form.Files.Count != 0 && editingItem.FileName != "" || 
            Request.Form.Files.Count == 0 && editingItem.FileName != "" && editItemViewModel.DeleteImage == "true")
        {
            this.DeleteFromCloud.DeleteFromCloud(editingItem.FileName);
            editingItem.FileName = resultingString;
        }
        else if (Request.Form.Files.Count != 0 && editingItem.FileName == "")
        {
            editingItem.FileName = resultingString;
        }

        await this.itemService.Save();

        return await Task.Run(() => Redirect($"/Home/ViewItem/{collectionId}/{itemId}"));
    }
}