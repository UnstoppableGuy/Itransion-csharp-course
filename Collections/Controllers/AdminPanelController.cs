using CollectionPR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace CollectionPR.Controllers;

public class AdminPanelController : Controller
{
    private readonly IUserValidation userValidation;
    private readonly IDeleteCloud DeleteFromCloud;
    private readonly IUserService userService;
    private readonly ICollectionService collectionService;
    private readonly IItemService itemService;

    public AdminPanelController(IUserValidation userValidation, IDeleteCloud DeleteFromCloud, IUserService userService, ICollectionService collectionService, IItemService itemService)
    {
        this.userService = userService;
        this.userValidation = userValidation;
        this.DeleteFromCloud = DeleteFromCloud;
        this.collectionService = collectionService;
        this.itemService = itemService;
    }
    
    [Authorize]
    public async Task<IActionResult> AdminPanel()
    {
        if (userValidation.IsUserNull(User.Identity!.Name!))
        {
            return await Task.Run(() => RedirectToAction("Logout", "Account"));   
        }

        if(!userValidation.IsUserAdminOrSuperAdmin(User.Identity!.Name!))
            return await Task.Run(() => RedirectToAction("Index", "Home"));

        return await Task.Run(() => View(userService.GetAllUsers()));
    }
    
    [Authorize]
    public async Task<IActionResult> Delete(string[] ids)
    {
        foreach (var id in ids)
        {
            var objectToDelete = await userService.GetUserById(id);

            var userCollections = collectionService.GetCollectionsByUserId(objectToDelete!.Id);

            foreach (var collection in userCollections)
            {
                var itemsToDelete = itemService.GetItemsByCollectionId(collection.Id);
                foreach (var item in itemsToDelete)
                {
                    if (item.FileName != "")
                    {
                        DeleteFromCloud.DeleteFromCloud(item.FileName);
                    }
                    
                    itemService.DeleteItem(item);
                }
                
                if (collection.FileName != "")
                {
                    DeleteFromCloud.DeleteFromCloud(collection.FileName);
                }
                
                collectionService.DeleteCollection(collection);
            }

            userService.Delete(objectToDelete);
        }

        return await Task.Run(() => RedirectToAction("AdminPanel"));
    }

    [Authorize]
    public async Task<IActionResult> Block(string[] ids)
    {
        foreach (var id in ids)
        {
            var objectToBlock = await userService.GetUserById(id);
            objectToBlock!.Status = "Blocked User";
            
            await userService.Save();

            if(objectToBlock.Email == User.Identity!.Name)
                return await Task.Run(() => RedirectToAction("Logout", "Account"));
        }

        return await Task.Run(() => RedirectToAction("AdminPanel"));
    }
    
    [Authorize]
    public async Task<IActionResult> Promote(string[] ids)
    {
        foreach (var id in ids)
        {
            var objectToPromote = await userService.GetUserById(id);
            objectToPromote!.Role = "admin";

            await userService.Save();
        }

        return await Task.Run(() => RedirectToAction("AdminPanel"));
    }
    
    [Authorize]
    public async Task<IActionResult> Demote(string[] ids)
    {
        foreach (var id in ids)
        {
            var objectToDemote = await userService.GetUserById(id);
            objectToDemote!.Role = "user";

            await userService.Save();

            if(objectToDemote.Email == User.Identity!.Name && objectToDemote.Role == "user")
                return await Task.Run(() => RedirectToAction("Index", "Home"));
        }

        return await Task.Run(() => RedirectToAction("AdminPanel"));
    }

    [Authorize]
    public async Task<IActionResult> Unblock(string[] ids)
    {
        foreach (var id in ids)
        {
            var objectToUnBlock = await userService.GetUserById(id);
            objectToUnBlock!.Status = "Active User";
        }

        await userService.Save();

        return await Task.Run(() => RedirectToAction("AdminPanel"));
    }
}