using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.WebAssembly.Services;
using System.Reflection;

namespace EngineAnalyticsWebApp.UI
{
    public partial class App
    {
        [Inject]
        private LazyAssemblyLoader assemblyLoader { get; set; } = default!;

        private List<Assembly> lazyLoadedAssemblies = new();

        private async Task OnNavigateAsync(NavigationContext args)
        {
            try
            {
                if (args.Path == "track-weather")
                {
                    var assemblies = await assemblyLoader.LoadAssembliesAsync(
                        new[] { "EngineAnalyticsWebApp.TestLazy.dll" });
                    lazyLoadedAssemblies.AddRange(assemblies);
                }
            }
            catch (Exception ex)
            {
                // Logger.LogError("Error: {Message}", ex.Message);
            }
        }
    }
}
