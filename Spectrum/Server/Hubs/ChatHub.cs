using Microsoft.AspNetCore.SignalR;
using Spectrum.Shared.Services;

namespace Spectrum.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task ToOthers(HubTUCarrier pack)
        {
            if (pack != null)
            {
                pack.ConnectionId = Context.ConnectionId;
                await Clients.Group(pack.RoomId!).SendAsync("MailBox", pack);
            }
        }

        public async Task ToCient(HubTUCarrier pack)
        {
            pack.ConnectionId = Context.ConnectionId;
            await Clients.Client(pack.ReceiverConId!).SendAsync("MailBox", pack);
        }
        public async Task JoinRoom(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            //await Clients.OthersInGroup(roomName).SendAsync("ReceiveMessage", new ScheduleData()
            //{
            //    ConnectionId = Context.ConnectionId,
            //    //Event = ScheduleEvent.Event.Planting,
            //    //EventType = ScheduleEvent.EventType.SeedRequest
            //});
        }

        public Task LeaveRoom(string roomName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

    }
}
