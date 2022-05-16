using Microsoft.AspNetCore.SignalR;

namespace CollectionPR.Services.Classes
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public virtual string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.Identity!.Name!;
        }
    }
}