using BlazingCollatz.Future.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection();
services.AddLogging();

var serviceProvider = services.BuildServiceProvider();
var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

await using var renderer = new HtmlRenderer(serviceProvider, loggerFactory);
var text = await renderer.Dispatcher.InvokeAsync(async () =>
{
    //var parameters = ParameterView.Empty;
    var parameters = ParameterView.FromDictionary(
        new Dictionary<string, object?>
        {
            { "Start", "456" }
        });
    var output = await renderer.RenderComponentAsync<CollatzGridMarkdown>(parameters);
    return output.ToHtmlString();
});

Console.WriteLine(text);
