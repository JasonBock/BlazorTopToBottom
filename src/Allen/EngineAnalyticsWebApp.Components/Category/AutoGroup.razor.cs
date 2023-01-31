using EngineAnalyticsWebApp.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace EngineAnalyticsWebApp.Components.Category
{
    public partial class AutoGroup
    {
        [CascadingParameter]
        public Automobile? automobile { get; set; }
    }
}
