using Microsoft.AspNetCore.SignalR;
using Spectrum.Shared.Services;

namespace Spectrum.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task ToOthers(HubTUCarrier pack)
        {
            pack.ConnectionId = Context.ConnectionId;
            await Clients.Others.SendAsync("MailBox", pack);
        }

        public async Task ToCient(HubTUCarrier pack)
        {
            pack.ConnectionId = Context.ConnectionId;
            await Clients.Client(pack.ReceiverConId!).SendAsync("MailBox", pack);
        }
        
   
    }
}
