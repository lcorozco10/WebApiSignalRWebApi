using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace WebApi.Server.Hub.Hub
{
    public class ChatHub : Hub<IClient>
    {
        public void NewMessage(string name, string message)
        {
            Clients.All.NewMessage(name, message);
        }
        public Task<int> Counter(int i)
        {
            return Clients.All.Counter(i);
        }

        public void CustomData(string name, string message)
        {
            Clients.All.AddContosoChatMessageToPage(new CustomChatMessage {UserName = name, Message = message});
        }
    }

    public interface IClient
    {
        void NewMessage(string name, string message);
        Task<int> Counter(int i);
        void AddContosoChatMessageToPage(CustomChatMessage customChatMessage);
    }
    public class CustomChatMessage
    {
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}