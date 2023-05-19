using Microsoft.Extensions.Logging;
using DeviceAPIAccess.Data;
using DeviceAPIAccess.Services;
using DeviceAPIAccess.Platforms.Services;

namespace DeviceAPIAccess;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();

		builder.Services.AddScoped<IGetText, GetText>();

		return builder.Build();
	}
}
