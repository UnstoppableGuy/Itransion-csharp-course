using CollectionPR.Models;
using CollectionPR.Services.Interfaces;
using Korzh.EasyQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace CollectionPR.Hub;

public class CommentsHub : Microsoft.AspNetCore.SignalR.Hub
{
    private readonly IServiceProvider serviceProvider;

    public CommentsHub(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    [Authorize]
    public async Task SendComment(string comment, string _itemId)
    {
        var itemId = _itemId.ToInt();
        
        using var scope = this.serviceProvider.CreateScope();
        
        var commentService = scope.ServiceProvider.GetRequiredService<ICommentService>();
        var userService = scope.ServiceProvider.GetRequiredService<IUserService>();

        var user = await userService.GetUserByEmail(Context!.User!.Identity!.Name!).ConfigureAwait(false);

        var commentTime = DateTime.UtcNow.AddHours(3).ToString("MM/dd/yyyy H:mm");
        
        var newComment = new Comment{ CommentText = comment, CommentWhen = commentTime, UserNickName = user.NickName, ItemId = itemId};
        
            
        await commentService.AddComment(newComment);

        var id = commentService.GetCommentIdByText(newComment);
            
        await Clients.All.SendAsync("ReceiveComment", user.NickName,comment, commentTime);
    }
}