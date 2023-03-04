using EngineAnalyticsWebApp.Shared.Services;
using EngineAnalyticsWebApp.Shared.Services.Factories;
using EngineAnalyticsWebApp.TestLazy.Messaging.Services;

namespace EngineAnalyticsWebApp.UI.Services
{
    public class MessageServiceFactory : IMessageServiceFactory
    {
        public MessageServiceFactory() { }

        public IMessageService Create() => new MessageService();
    }
}
