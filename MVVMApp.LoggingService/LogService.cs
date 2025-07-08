using MVVMApp.Services;

namespace MVVMApp.LoggingService
{
    public class LogService : ILogService
    {
        public LogService()
        {
            System.Diagnostics.Debug.WriteLine("Creating Log service");
        }

        public void Log(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }
    }
}
