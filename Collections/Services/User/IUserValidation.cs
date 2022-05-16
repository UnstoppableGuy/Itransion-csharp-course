using CollectionPR.Models;

namespace CollectionPR.Services.Interfaces;

public interface IUserValidation
{
    bool IsUserNullOrBlocked(string email);
    bool IsUserNull(string email);
    bool IsUserAdminOrSuperAdmin(string email);
    bool IsUserIsAuthenticatedAndNull(string email, bool isAuthenticated);
}