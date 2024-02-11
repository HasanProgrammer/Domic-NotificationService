using Domic.Core.Common.ClassHelpers;
using Microsoft.AspNetCore.SignalR;

namespace Domic.WebAPI.EntryPoints.Hubs;

public class PushNotificationHub : Hub
{
    public string GetConnectionId() => Context.ConnectionId;

    public async Task PushAsync(NotificationMessage message)
    {
        if(!string.IsNullOrEmpty(message.ConnectionId))
            await Clients.Client(message.ConnectionId).SendAsync("PullNotification", message.Payload);
    }
}