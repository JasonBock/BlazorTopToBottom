using EngineAnalyticsWebApp.Shared.Models.Engine;
using Microsoft.AspNetCore.Components;

namespace EngineAnalyticsWebApp.Components.Category
{
    public partial class AutoGroup
    {
        [CascadingParameter]
        public Automobile? automobile { get; set; }
    }
}
