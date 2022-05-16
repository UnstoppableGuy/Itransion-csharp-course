using CollectionPR.Data.Interfaces;
using CollectionPR.Models;
using CollectionPR.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CollectionPR.Services.Classes;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly UserManager<User> userManager;

    public UserService(IUserRepository userRepository, UserManager<User> userManager)
    {
        this.userRepository = userRepository;
        this.userManager = userManager;
    }

    public async Task<IdentityResult> SaveNewUser(User user, string password)
    {
        var result = await this.userManager.CreateAsync(user, password);
        this.userManager.PasswordHasher = new PasswordHasher<User>();
        this.userManager.PasswordHasher.HashPassword(user, password);

        return result;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await Task.FromResult(this.userRepository.GetSingleAsync(u => u.UserName == email).GetAwaiter().GetResult()!);
    }

    public List<User> GetAllUsers()
    {
        return this.userRepository.GetAll().ToList();
    }

    public async ValueTask Save()
    {
        await this.userRepository.CommitAsync();
    }

    public async Task<User?> GetUserById(string id)
    {
        return await this.userRepository.FindAsync(id);
    }

    public void Delete(User user)
    {
        this.userRepository.Delete(user);
    }
}