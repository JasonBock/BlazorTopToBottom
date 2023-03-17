using EngineAnalyticsWebApp.Shared.Services;
using EngineAnalyticsWebApp.Shared.Services.Factories;
using Microsoft.AspNetCore.Components;

namespace EngineAnalyticsWebApp.TestLazy.Messaging
{
    public partial class MessageComponent
    {
        [Parameter]
        public string? Message { get; set; }
        private string? formattedMessage;
        [Inject]
        private IMessageServiceFactory messageServiceFactory { get; set; } = default!;

        protected override void OnInitialized()
        {
            IMessageService messageService = messageServiceFactory.Create();
            if(!string.IsNullOrEmpty(Message))
            {
                formattedMessage = messageService.MessageLogger(Message);

            }
        }
    }
}
