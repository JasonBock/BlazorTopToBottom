using Microsoft.AspNetCore.Components;

namespace EngineAnalyticsWebApp.Components.Reporting
{
    public partial class ReportHeader
    {

        [Parameter]
        public string Title { get; set; } = default!;

        [Parameter]
        public RenderFragment ChildContent { get; set; } = default!;

    }
}
