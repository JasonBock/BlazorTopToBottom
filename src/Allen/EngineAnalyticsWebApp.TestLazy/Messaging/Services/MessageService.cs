using EngineAnalyticsWebApp.Shared.Services;

namespace EngineAnalyticsWebApp.TestLazy.Messaging.Services
{
    public class MessageService : IMessageService
    {
        public string MessageLogger(string message)
        {
            Console.WriteLine(message);
            return $"You logged: '{message}'";
        }
    }
}
