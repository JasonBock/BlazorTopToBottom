using EngineAnalyticsWebApp.Components.Calculations.Services;
using EngineAnalyticsWebApp.Shared.Models;
using EngineAnalyticsWebApp.Shared.Models.Engine;
using EngineAnalyticsWebApp.Shared.Services.Data;
using Microsoft.AspNetCore.Components;

namespace EngineAnalyticsWebApp.Components.Calculations
{
    public partial class HorsepowerCalculation
    {
        [Inject]
        private IAutomobileDataService AutomobileDataService { get; set; } = default!;
        [Inject]
        private IEngineCalculationsService EngineCalculationsService { get; set; } = default!;


        private Automobile automobile = new()
        {
            Horsepower = new Horsepower(),
            EngineAnalytics = new EngineAnalytics() { FlywheelHorsepower = 0, RearWheelHorsepower = 0 }
        };


        private string statusMessage = string.Empty;
        private string alertClass = string.Empty;

        private async Task HandleValidSubmit()
        {
            if (automobile.Horsepower?.Weight != null && automobile.Horsepower?.EstimatedTime != null)
            {
                automobile.EngineAnalytics = this.EngineCalculationsService.CalculateEngineHorsepower(automobile.Horsepower);
                await this.AutomobileDataService.AddAutomobile(automobile);
                statusMessage = "Successfully saved calculations";
                alertClass = "alert-success";
                StateHasChanged();  // required as the async nature post-await not updating the UI until next action
            }
            else
            {
                statusMessage = "Required fields are missing";
                alertClass = "alert-danger";
            }
        }

        private void HandleInValidSubmit()
        {
            statusMessage = "Required fields are missing";
            alertClass = "alert-danger";
        }

        private void ClearForm()
        {
            statusMessage = string.Empty;
            alertClass = string.Empty;
        }
    }
}
