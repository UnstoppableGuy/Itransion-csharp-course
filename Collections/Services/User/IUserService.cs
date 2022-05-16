using CollectionPR.Models;
using Microsoft.AspNetCore.Identity;

namespace CollectionPR.Services.Interfaces;

public interface IUserService
{
    Task<IdentityResult> SaveNewUser(User user, string password);
    Task<User> GetUserByEmail(string email);
    ValueTask Save();
    List<User> GetAllUsers();
    Task<User?> GetUserById(string id);
    void Delete(User user);
}