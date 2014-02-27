using Microsoft.AspNet.SignalR;

namespace SignalRCodemash.Hubs
{
    public class MyChatHub : Hub
    {
        public void Hello(string name, string message)
        {
            Clients.All.hello(name, message);
        }
    }

    public class MyChat
    {
        public string Name { get; set; }
        public string Message { get; set; }
    }
}