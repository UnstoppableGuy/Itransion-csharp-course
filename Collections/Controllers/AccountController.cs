using CollectionPR.Models;
using CollectionPR.Services.Interfaces;
using CollectionPR.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CollectionPR.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<User> signInManager;

    private readonly IUserService userService;
    private readonly IUserValidation userValidation;

    public AccountController(SignInManager<User> signInManager, IUserValidation userValidation, IUserService userService)
    {
        this.signInManager = signInManager;
        this.userValidation = userValidation;
        this.userService = userService;
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid) 
            return await Task.Run(() => View(model));
        
        var user = new User { Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, NickName = model.NickName, UserName = model.Email, RegisterDate = DateTime.Now, LastLoginDate = DateTime.Now, Role = model.Role, Status = "Active User"};
        
        var result = await userService.SaveNewUser(user, model.Password!);
        
        if (result.Succeeded)
        {
            await signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        
        return await Task.Run(() => View(model));
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return await Task.Run(() => View(model));

        if (userValidation.IsUserNullOrBlocked(model.Email!)) 
            return RedirectToAction("Index", "Home");

        var result = 
            await signInManager.PasswordSignInAsync(model.Email, model.Password!, model.RememberMe, false);

        if (result.Succeeded)
        {
            var user = await userService.GetUserByEmail(model.Email!);
            
            user.LastLoginDate = DateTime.Now;

            await userService.Save();
            
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Incorrect email and (or) password!");

        return await Task.Run(() => View(model));
    }
    
    
    [Route("/Account/Logout")]
    public async Task<IActionResult> Logout()
    {
        if (userValidation.IsUserNull(User.Identity!.Name!))
        {
            await signInManager.SignOutAsync();
            return await Task.Run(() => RedirectToAction("Index", "Home"));
        }
        
        var user = await userService.GetUserByEmail(User.Identity.Name!);
        user.LastLoginDate = DateTime.Now;

        await userService.Save();
        await signInManager.SignOutAsync();
        
        return await Task.Run(() => RedirectToAction("Index", "Home"));
    }
}