using EngineAnalyticsWebApp.Shared.Models.Engine;
using EngineAnalyticsWebApp.Shared.Services.Data;
using Microsoft.AspNetCore.Components;

namespace EngineAnalyticsWebApp.Components.Reporting
{
    public partial class DisplacementDataGrid
    {
        [Inject]
        private IAutomobileDataService AutomobileDataService { get; set; } = default!;

        private IEnumerable<Automobile> automobileData = new List<Automobile>();
        private Automobile? selectedAutomobile;

        protected override async Task OnInitializedAsync()
        {
            automobileData = await AutomobileDataService.GetAutomobiles();
            automobileData = automobileData.Where(x => x.EngineAnalytics?.Displacement != 0).ToList();
        }
    }
}
