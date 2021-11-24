using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Data.Hubs
{
    public class SimulationHub : Hub
    {
        public async Task Connect()
        {
            Console.WriteLine($"Client {Context.ConnectionId} started a virtual simulation.");

            await Clients.Caller.SendAsync("ReceiveMessage", "Welcome to the hub.");
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
