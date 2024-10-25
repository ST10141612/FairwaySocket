using System;
using Microsoft.AspNetCore.SignalR;
using SignalRServer.Models;

namespace SignalRServer.Hubs
{
    public class GameHub : Hub<IGameHubClient>
    {

        public async Task BroadcastUpdate(UpdateInstruction update)
        {
            await Clients.Others.ReceiveUpdate(update);
        }

        public async Task BroadcastScoreToGroup(string groupName, UpdateInstruction instruction)
        {
            await Clients.OthersInGroup(groupName).ReceiveUpdate(instruction);
        }

        public async Task AddPlayerToGame(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task RemovePlayerFromGame(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}
