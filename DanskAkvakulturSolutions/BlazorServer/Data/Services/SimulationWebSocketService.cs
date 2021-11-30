using BlazorServer.Data.Hubs;
using BlazorServer.Data.Services.Interfaces;
using BlazorServer.Data.Settings;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Data.Services
{
    public class SimulationWebSocketService : CoreHub, ISimulationService
    {
        private readonly ILogger<SimulationWebSocketService> _logger;

        public SimulationWebSocketService(ILogger<SimulationWebSocketService> logger, ISimulationSettings simulationSettings, NavigationManager nav) 
            : base(logger, simulationSettings, nav)
        {
            _logger = logger;
        }

        public async Task ConnectAsync()
        {
            await base.StartConnectionAsync();
        }

        public async Task SendMessageAsync()
        {
            await base.SendAsync();
        }
    }    
}
