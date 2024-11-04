using Microsoft.AspNetCore.SignalR;

namespace ProyectoManahttan.Application
{
    public class NotificationHub : Hub<INotificationClient>
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Client(Context.ConnectionId).ReceiveNotification($"Thank you for connecting {Context.ConnectionId}");
            await base.OnConnectedAsync();
        }
    }

    public interface INotificationClient
    {
        Task ReceiveNotification(string message); 
    }
}

