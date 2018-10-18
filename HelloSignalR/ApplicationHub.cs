using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloSignalR.Extensions;
using HelloSignalR.Models;
using Microsoft.AspNetCore.SignalR;

namespace HelloSignalR
{
    // ReSharper disable once ClassNeverInstantiated.Global
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
            if (Users.All(x => x.ConnectionId != Context.ConnectionId))
                return Clients.Client(Context.ConnectionId).SendAsync("NotRegistered");

            Users.RemoveOne(x => x.ConnectionId == Context.ConnectionId);
            return Clients.Client(Context.ConnectionId).SendAsync("UnRegistered");
        }


        public Task Send(string message)
        {
            if (Users.All(x => x.ConnectionId != Context.ConnectionId))
                return Clients.Client(Context.ConnectionId).SendAsync("NeedToRegister");
            
            return Clients.All.SendAsync("Send", message);
        }

        public async Task SendToUser(string name, string message)
        {
            var connectionId = Users.FirstOrDefault(x => x.Name == name)?.ConnectionId;

            if (connectionId == null)
                await Clients.Client(Context.ConnectionId).SendAsync("FailedToSendMessage", name, message);
            else
            {
                await Clients.Client(connectionId).SendAsync("ReceivedFrom", Context.ConnectionId, message);
                await Clients.Client(Context.ConnectionId).SendAsync("SentMessage", name, message);
            }
        }
    }
}