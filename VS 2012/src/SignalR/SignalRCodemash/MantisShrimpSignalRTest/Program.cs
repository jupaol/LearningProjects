using System;
using System.Net;
using Microsoft.AspNet.SignalR.Client;

namespace MantisShrimpSignalRTest
{
    public class LogMessageModel
    {
        public Guid LogMessageId { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public string StackTrace { get; set; }
        public Guid DeploymentLogId { get; set; }
        public string LogType { get; set; }
    }

    class Program
    {
        static void Main()
        {
            using (var i = new Impersonation("igsdomain", "jolmos", "JPol.291179"))
            {
                var connection = new HubConnection("http://localhost:34080/");
                connection.Credentials = CredentialCache.DefaultCredentials;
                var hub = connection.CreateHubProxy("LogsHub");

                connection.Start().Wait();
                //.ContinueWith(task =>
                //{
                //    if (task.IsFaulted)
                //    {
                //        Console.WriteLine("There was an error opening the connection:{0}",
                //                          task.Exception.GetBaseException());
                //        Console.ReadLine();
                //        Environment.Exit(1);
                //    }
                //    else
                //    {
                //        Console.WriteLine("Connected");
                //    }
                //}).Wait();

                var hardCodedGuid = new Guid("63ff8081-b43b-474a-a493-f8c3534f7324");
                var existingLogMessageId = new Guid("60D8E681-BE51-4934-B883-28037E6CC328");
                var ff = new Guid("011CCAB6-D901-469B-9DDC-15E08383CCE7");

                //.ContinueWith(task =>
                //{
                //    if (task.IsFaulted)
                //    {
                //        Console.WriteLine("There was an error calling send: {0}",
                //                          task.Exception.GetBaseException());
                //    }
                //    else
                //    {
                //        Console.WriteLine("done");
                //    }
                //}).RunSynchronously();

                hub.Invoke("NewLog", hardCodedGuid.ToString(), new LogMessageModel
                {
                    LogMessageId = Guid.NewGuid(),
                    Message = "1",
                    DeploymentLogId = hardCodedGuid,
                    TimeStamp = DateTime.Now
                }).Wait();

                hub.Invoke("NewLog", hardCodedGuid.ToString(), new LogMessageModel
                {
                    LogMessageId = existingLogMessageId,
                    Message = "2",
                    DeploymentLogId = hardCodedGuid,
                    TimeStamp = DateTime.Now
                }).Wait();

                hub.Invoke("NewLog", hardCodedGuid.ToString(), new LogMessageModel
                {
                    LogMessageId = ff,
                    Message = "3",
                    DeploymentLogId = hardCodedGuid,
                    TimeStamp = DateTime.Now
                }).Wait();

                hub.Invoke("NewLog", hardCodedGuid.ToString(), new LogMessageModel
                {
                    LogMessageId = Guid.NewGuid(),
                    Message = "4",
                    DeploymentLogId = hardCodedGuid,
                    TimeStamp = DateTime.Now
                }).Wait();


                //hub.On<string>("NewLog",
                //    (name) => Console.WriteLine("{0} - {1}", name));

                Console.Read();

                connection.Stop();

            }
        }
    }
}
