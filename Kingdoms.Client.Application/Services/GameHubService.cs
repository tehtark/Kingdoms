using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace Kingdoms.Client.Application.Services;

internal class GameHubService
{
    private NavigationManager _navigationManager;
    private HubConnection? _hubConnection;

    public GameHubService(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }

    public async Task ConnectAsync()
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl(_navigationManager.ToAbsoluteUri("/gamehub")) // Use NavigationManager
            .Build();

        // Add event handlers for connection events (optional)
        _hubConnection.Closed += async (error) => {
            // Handle connection closed (e.g., attempt to reconnect)
            await Task.Delay(new Random().Next(0, 5) * 1000);
            await _hubConnection.StartAsync();
        };

        await _hubConnection.StartAsync();
    }
}