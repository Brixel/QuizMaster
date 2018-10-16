using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace HelloSignalR
{
    public class ApplicationHub : Hub
    {
        public Task Send(string message)
        {
            return Clients.All.SendAsync("Send", message);
        }
    }
}