using Microsoft.AspNetCore.Mvc;
using CollectionPR.Models;
using CollectionPR.Services;
using CollectionPR.Services.Interfaces;
using CollectionPR.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CollectionPR.Controllers;

public class CreateController : Controller
{
    private readonly ISaveFileAsync saveFileAsync;
    private readonly ICollectionService collectionService;
    private readonly IItemService itemService;
    

    public CreateController(ISaveFileAsync saveFileAsync, IItemService itemService, ICollectionService collectionService)
    {
        this.saveFileAsync = saveFileAsync;
        this.itemService = itemService;
        this.collectionService = collectionService;
    }
    
    [Authorize]
    [HttpGet]
    public IActionResult CreateView()
    {
        return View("CreateCollection");
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateCollection(CollectionViewModel collectionViewModel)
    {
        if (!ModelState.IsValid || collectionViewModel.Theme == "null") 
            return await Task.Run(() => View(collectionViewModel));

        var resultingString = "";

        if (Request.Form.Files.Count != 0)
        {
            var file = Request.Form.Files[0];
            resultingString = this.saveFileAsync.SaveFileAsync(file).Result;
        }

        var newCollection = new Collection
        {
            AuthorId = collectionViewModel.AuthorId, Title = collectionViewModel.Title,
            Description = collectionViewModel.Description, Theme = collectionViewModel.Theme,
            AddDates = collectionViewModel.IncludeDate, AddBrands = collectionViewModel.IncludeBrand,
            AddComments = collectionViewModel.IncludeComments, LastEditDate = DateTime.UtcNow.AddHours(3).ToString("MM/dd/yyyy H:mm"),
            FileName = resultingString,
        };

        this.collectionService.AddCollection(newCollection);

        return await Task.Run(() => RedirectToAction("ViewCollection", "Home", this.collectionService.GetCollectionById(newCollection.Id)));
    }

    [HttpGet]
    [Route("/Home/AddItem/{collectionId:int}")]
    public IActionResult AddItem(int collectionId)
    {
        ViewBag.collectionId = collectionId;

        return View("AddItem");
    }
    
    [Authorize]
    [HttpPost]
    [Route("/Home/AddItem/{collectionId:int}")]
    public async Task<IActionResult> AddItem(ItemViewModel itemViewModel, int collectionId)
    {
        ViewBag.collectionId = collectionId;
        
        if (!ModelState.IsValid) 
            return await Task.Run(() => View(itemViewModel));

        var resultingStrings = ""; 

        if (Request.Form.Files.Count != 0)
        {
            var file = Request.Form.Files[0];
            resultingStrings = this.saveFileAsync.SaveFileAsync(file).Result;
        }

        
        var newItem = new Item
        {
            CollectionId = itemViewModel.CollectionId, Title = itemViewModel.Title,
            Description = itemViewModel.Description, LastEditDate = DateTime.UtcNow.AddHours(3).ToString("MM/dd/yyyy H:mm"),
            Date = itemViewModel.Date, Brand = itemViewModel.Brand, FileName = resultingStrings,
        };

        var currentCollection = this.collectionService.GetCollectionByItemId(newItem.CollectionId);

        currentCollection.CollectionItems!.Add(newItem);

        await this.itemService.AddItem(newItem);

        return await Task.Run(() => RedirectToAction("ViewCollection", "Home", currentCollection));
    }   
}