using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CollectionPR.Models;
using CollectionPR.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CollectionPR.Controllers;

public class HomeController : Controller
{
    private readonly IUserService userService;
    private readonly IUserValidation userValidation;
    private readonly ICollectionService collectionService;
    private readonly IItemService itemService;
    private readonly ILikeService likeService;
    private readonly ICollectionValidation collectionValidation;
    private readonly IItemValidation itemValidation;
    private readonly ILikeValidation likeValidation;
    
    public HomeController(IUserValidation userValidation, ICollectionValidation collectionValidation, IItemValidation itemValidation, ILikeValidation likeValidation, IUserService userService, ICollectionService collectionService, IItemService itemService, ILikeService likeService)
    {
        this.userValidation = userValidation;
        this.collectionValidation = collectionValidation;
        this.itemValidation = itemValidation;
        this.likeValidation = likeValidation;
        this.userService = userService;
        this.collectionService = collectionService;
        this.itemService = itemService;
        this.likeService = likeService;
    }
    
    public async Task<IActionResult> Index()
    {
        if (this.userValidation.IsUserIsAuthenticatedAndNull(User.Identity!.Name!, User.Identity.IsAuthenticated))
            return await Task.Run(() => RedirectToAction("Logout", "Account"));

        var user = await this.userService.GetUserByEmail(User.Identity.Name!);
        
        return await Task.Run(() => View(user));
    }
    
    [Authorize]
    public async Task<IActionResult> Profile()
    {
        if (this.userValidation.IsUserNullOrBlocked(User.Identity!.Name!))
            return await Task.Run(() => RedirectToAction("Register", "Account"));

        var user = await this.userService.GetUserByEmail(User.Identity.Name!);

        return await Task.Run(() => View(user));
    }

    [Route("/Home/ViewCollection/{collectionId:int}")]
    public async Task<IActionResult> ViewCollection(int collectionId)
    {
        if (this.collectionValidation.IsCollectionNull(collectionId)) 
            return await Task.Run(() => RedirectToAction("Profile", "Home"));
        
        var userCollection = this.collectionService.GetCollectionById(collectionId);
        userCollection.CollectionItems = this.itemService.GetItemsByCollectionId(collectionId);

        return await Task.Run(() => View(userCollection));
    }

    [HttpGet]
    [Route("/Home/ViewItem/{collectionId}/{itemId:int}")]
    public async Task<IActionResult> ViewItem(int itemId)
    {
        if (this.itemValidation.IsItemNull(itemId)) 
            return await Task.Run(() => RedirectToAction("Profile", "Home"));

        var item = this.itemService.GetItemById(itemId);

        item.Likes = this.likeService.GetLikesByItemId(item.Id);
        
        Console.WriteLine("Count: " + item.Likes.Count);

        return await Task.Run(() => View(item));
    }
    
    [HttpPost]
    [Route("/Home/{collectionId::int}/{itemId::int}/ToggleLike")]
    public async Task<IActionResult> ToggleLike(int collectionId, int itemId)
    {
        if (!User.Identity!.IsAuthenticated)
            return await Task.Run(() => BadRequest("You must to be authorized to place likes!"));       
                
        if (this.likeValidation.IsUserOwner(User.Identity!.Name!, collectionId)) 
            return await Task.Run(() => BadRequest("You can't like your own item"));

        var item = this.itemService.GetItemById(itemId);

        var userId = this.userService.GetUserByEmail(User.Identity.Name!).GetAwaiter().GetResult().Id;
        var existingLike = this.likeService.IsLikeExists(userId, item.Id);
        
        if (existingLike == null)
        {
            this.likeService.AddLike(new Like { UserId = userId, ItemId = itemId });
        }
        else
        {
            this.likeService.DeleteLike(existingLike);
        }

        return await Task.Run(NoContent);
    }
    
    [Route("/Home/GetAmountOfLikes/{itemId:int}")]
    public int GetAmountOfLikes(int itemId)
    {
        return this.likeService.GetLikesByItemId(itemId).Count;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}