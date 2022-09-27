using Microsoft.AspNetCore.SignalR;

namespace DotSheepFight.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendInfo(string user, string info)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, info);
        }
    }
}
