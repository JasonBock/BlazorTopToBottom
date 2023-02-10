﻿using EngineAnalyticsWebApp.Shared.Models.Engine;
using EngineAnalyticsWebApp.Shared.Services.Data;
using Microsoft.AspNetCore.Components;

namespace EngineAnalyticsWebApp.Components.Reporting
{
    public partial class HorsepowerDataGrid
    {
        [Inject]
        private IAutomobileDataService AutomobileDataService { get; set; } = default!;

        private IEnumerable<Automobile> automobileData = new List<Automobile>();

        protected override async Task OnInitializedAsync()
        {
            automobileData = await AutomobileDataService.GetAutomobiles();
            automobileData = automobileData.Where(x => x.EngineAnalytics?.RearWheelHorsepower != 0).ToList();
        }
    }
}
