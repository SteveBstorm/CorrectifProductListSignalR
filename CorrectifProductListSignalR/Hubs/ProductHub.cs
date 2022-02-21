using CorrectifProductListSignalR.Data;
using Microsoft.AspNetCore.SignalR;

namespace CorrectifProductListSignalR.Hubs
{
    public class ProductHub : Hub
    {
       
        public async Task RefreshList()
        {
            await Clients.All.SendAsync("updateList");
        }
    }
}
