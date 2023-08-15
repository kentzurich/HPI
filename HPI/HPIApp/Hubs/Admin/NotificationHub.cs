using Microsoft.AspNetCore.SignalR;

namespace HPIApp.Hubs.Admin
{
    public class NotificationHub : Hub
    {
        public static int notificationCounter = 0;
        public static List<string> messages = new();

        public async Task SendMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                notificationCounter++;
                messages.Add(message);
                await Clients.Others.SendAsync("newMessageNotification");
                await LoadMessages();
            }
        }

        public async Task LoadMessages()
        {
            await Clients.All.SendAsync("LoadNotification", messages, notificationCounter);
        }
    }
}
