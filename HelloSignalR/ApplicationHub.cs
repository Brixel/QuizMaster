using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloSignalR.Extensions;
using HelloSignalR.Models;
using Microsoft.AspNetCore.SignalR;

namespace HelloSignalR
{
    public class ApplicationHub : Hub
    {
        public List<User> Users { get; set; }
        

        public Task Register(string name)
        {
            if (Users.Any(x => x.ConnectionId == Context.ConnectionId))
                return Clients.Client(Context.ConnectionId).SendAsync("AlreadyRegistered");

            Users.Add(new User { Name = name, ConnectionId = Context.ConnectionId });
            return Clients.Client(Context.ConnectionId).SendAsync("Registered");
        }

        public Task UnRegister()
        {
            if (!Users.Any(x => x.ConnectionId == Context.ConnectionId))
                return Clients.Client(Context.ConnectionId).SendAsync("NotRegistered");

            Users.RemoveOne(x => x.ConnectionId == Context.ConnectionId);
            return Clients.Client(Context.ConnectionId).SendAsync("UnRegistered");
        }


        public Task Send(string message)
        {
            if (!Users.Any(x => x.ConnectionId == Context.ConnectionId))
                return Clients.Client(Context.ConnectionId).SendAsync("NeedToRegister");
            
            return Clients.All.SendAsync("Send", message);
        }
    }
}