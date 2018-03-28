using System;
using Microsoft.AspNet.SignalR;

namespace SignalR.Hub
{
    public class ChatHub : Microsoft.AspNet.SignalR.Hub
    {
        private static readonly IHubContext HubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();

        public void CustomData(CustomData customData)
        {
            HubContext.Clients.All.CustomData(customData, DateTime.UtcNow);
        }
    }

    public class CustomData
    {
        public string Name { get; set; }
        public string Message { get; set; }
    }
}
