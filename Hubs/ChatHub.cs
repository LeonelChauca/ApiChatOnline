using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace ApiChatOnline.Hubs;

[Authorize]
public class ChatHub : Hub
{
    private static readonly Dictionary<string, string> _userConnections = new();

    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public override async Task OnConnectedAsync()
    {
        var userId =
            Context.UserIdentifier ?? Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!string.IsNullOrEmpty(userId))
        {
            _userConnections[userId] = Context.ConnectionId;
            var listaOnline = _userConnections.Keys.ToList();
            await Clients.Caller.SendAsync("UsersOnline", listaOnline);
            await Clients.Others.SendAsync("NewUser", userId);
            Console.WriteLine($"User {userId} connected with ConnectionId: {Context.ConnectionId}");
        }
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var item = _userConnections.FirstOrDefault(x => x.Value == Context.ConnectionId);
        if (!string.IsNullOrEmpty(item.Key))
        {
            _userConnections.Remove(item.Key);
            await Clients.Others.SendAsync("UserDisconnected", item.Key);
        }
        await base.OnDisconnectedAsync(exception);
    }
}
