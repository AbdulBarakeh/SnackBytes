using Microsoft.AspNetCore.SignalR;
namespace SchedulingApp.Server.Hubs;

public class CalendarHub: Hub
{
    public async Task DoNextStep()
    {
        await Clients.All.SendAsync("NextStep");
    }
    public async Task DoPreviousStep()
    {
        await Clients.All.SendAsync("PreviousStep");
    }
}
