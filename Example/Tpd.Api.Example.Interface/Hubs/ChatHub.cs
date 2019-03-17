using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Tpd.Api.Interface.Hubs
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        //https://github.com/dyatchenko/ServiceBrokerListener
        //http://elvanydev.com/SignalR-Core-SqlDependency-part1/
        //http://elvanydev.com/SignalR-Core-SqlDependency-part2
        //https://stackoverflow.com/questions/51637287/core-2-1-signalr-and-sqldependency
    }
}
