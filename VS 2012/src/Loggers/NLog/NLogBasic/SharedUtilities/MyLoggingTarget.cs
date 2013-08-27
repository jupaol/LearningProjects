using NLog.Targets;

namespace SharedUtilities
{
    [Target(Targets.MyLoggingTargetName)]
    public class MyLoggingTarget : TargetWithLayout
    {
        protected override void Write(NLog.LogEventInfo logEvent)
        {
            var logMessage = Layout.Render(logEvent);

            SendLogToQueue(logMessage);
        }

        private void SendLogToQueue(string message)
        {
            
        }
    }
}
