using Microsoft.AspNetCore.SignalR;

namespace Instagram_Clone_Backend.Models
{
    public class InstagramHub:Hub
    {
        public async Task SendNotification(string message)
        {
            await Clients.All.SendAsync("Message", message);
        }
    }
}
