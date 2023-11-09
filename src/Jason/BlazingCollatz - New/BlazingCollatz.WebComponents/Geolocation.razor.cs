using Microsoft.JSInterop;

namespace BlazingCollatz.WebComponents;

public partial class Geolocation
{
	double accuracy { get; set; }
	string? bingMainUrl { get; set; }
	string? bingLargeMapUrl { get; set; }
	string? bingDirectionsUrl { get; set; }
	double latitude { get; set; }
	double longitude { get; set; }

	private DotNetObjectReference<Geolocation>? reference;

	[JSInvokable]
	public void Change(double latitude, double longitude, double accuracy)
	{
		(this.latitude, this.longitude, this.accuracy) = (latitude, longitude, accuracy);
		this.bingMainUrl = $"https://www.bing.com/maps/embed?h=400&w=500&cp={latitude}~{longitude}&lvl=11&typ=d&sty=r&src=SHELL&FORM=MBEDV8";
		this.bingLargeMapUrl = $"https://www.bing.com/maps?cp={latitude}~{longitude}&amp;sty=r&amp;lvl=11&amp;FORM=MBEDLD";
		this.bingDirectionsUrl = $"https://www.bing.com/maps/directions?cp={latitude}~-{longitude}&amp;sty=r&amp;lvl=11&amp;rtp=~pos.{latitude}_{longitude}____&amp;FORM=MBEDLD";
		this.StateHasChanged();
	}

	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		if (firstRender)
		{
			this.reference = DotNetObjectReference.Create(this);

			var module = await this.JSRuntime.InvokeAsync<IJSObjectReference>(
				  Constants.Import, Constants.GeolocationFileLocation);

			await module.InvokeAsync<object>(
				 Constants.GeolocationMethod, this.reference);
		}
	}

	public void Dispose()
	{
		GC.SuppressFinalize(this);

		this.reference?.Dispose();
	}
}
