using Avalonia;
using Avalonia.Browser;
using Avalonia.ReactiveUI;
using BlazingCollatz.AvaloniaApplication;
using System.Runtime.Versioning;

[assembly: SupportedOSPlatform("browser")]

internal partial class Program
{
   private static void Main(string[] args) => BuildAvaloniaApp()
	   .UseReactiveUI()
	   .SetupBrowserApp("out");

   public static AppBuilder BuildAvaloniaApp()
	   => AppBuilder.Configure<App>();
}