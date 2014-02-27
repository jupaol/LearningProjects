using System;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRNetClient
{
    class Program
    {
        static void Main()
        {
            var connection = new HubConnection("http://localhost:8640/");
            var hub = connection.CreateHubProxy("MyChatHub");

            connection.Start().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error opening the connection:{0}",
                                      task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("Connected");
                }
            }).Wait();

            hub.Invoke("Hello", "MyName", "HELLO World ").ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error calling send: {0}",
                                      task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("done");
                }
            });

            hub.On<string, string>("hello",
                (name, message) => Console.WriteLine("{0} - {1}", name, message));

            Console.Read();

            connection.Stop();
        }
    }
}
