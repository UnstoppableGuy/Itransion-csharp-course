using CollectionPR.Data.Interfaces;
using CollectionPR.Services.Interfaces;

namespace CollectionPR.Services.Classes;

public class UserValidationService : IUserValidation
{
    private readonly IUserRepository userRepository;
    
    public UserValidationService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }
    
    public bool IsUserNullOrBlocked(string email)
    {
        var user = this.userRepository.GetSingleAsync(u => u.UserName == email).Result;

        return user == null || user.Status == "Blocked User";
    }

    public bool IsUserNull(string email)
    {
        var user = this.userRepository.GetSingleAsync(u => u.UserName == email).Result;
        
        return user == null;
    }

    public bool IsUserAdminOrSuperAdmin(string email)
    {
        var user = this.userRepository.GetSingleAsync(u => u.UserName == email).Result;

        return user!.Role is "admin" or "super admin";
    }

    public bool IsUserIsAuthenticatedAndNull(string email, bool isAuthenticated)
    {
        var user = this.userRepository.GetSingleAsync(user => user.UserName == email && user.Status != "Blocked User").Result;

        Console.WriteLine(isAuthenticated);

        return user == null && isAuthenticated;
    }
}