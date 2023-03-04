
using EngineAnalyticsWebApp.Components.Weather.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace EngineAnalyticsWebApp.Components.Weather
{
    public partial class WeatherLocation
    {
        private string title = "Track Weather";
        private string? zipCode;
        private IJSObjectReference? module;
        // private Lazy<IJSObjectReference> moduleTask;
        private string? result;

        [Inject]
        private IWeatherService weatherService { get; set; } = default!;
        [Inject]
        private IJSRuntime JS { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await weatherService.SetWeatherZipCode(zipCode);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                module = await JS.InvokeAsync<IJSObjectReference>(
                    "import", "./_content/EngineAnalyticsWebApp.Components/Weather/WeatherLocation.razor.js");
                //moduleTask = await JS.InvokeAsync<IJSObjectReference>("import",
                //    "./_content/EngineAnalyticsWebApp.Components/Weather/WeatherLocation.razor.js");
            }
        }

        public async Task UpdateZipCode(KeyboardEventArgs e)
        {
            
            if ((e.Code == "Enter" || e.Code == "NumpadEnter") && !string.IsNullOrEmpty(zipCode))
            {
                // Call service to set zip code
                await weatherService.SetWeatherZipCode(zipCode);
            }
            
        }

        public async Task useCurrentGeolocation()
        {
            //var text = await module.InvokeAsync<string>("useCurrentGeolocation");
             var coords = await UseCurrentGeolocation();
            //var currentPositionResult = await GetCurrentPosition();
            // var testText = "Hello";
            result = await Prompt($"Your location is Latitude: {coords.Latitude} and Longitude: {coords.Longitude}");
            //result = await UseCurrentGeolocation();
        }

        //private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        //public ExampleJsInterop(IJSRuntime jsRuntime)
        //{
        //    moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
        //        "import", "./_content/EngineAnalyticsWebApp.Components/exampleJsInterop.js").AsTask());
        //}

        public async ValueTask<string?> Prompt(string message) =>
            module is not null ?
                await module.InvokeAsync<string>("showPrompt2", message) : null;

        public async ValueTask<GeoLocationCoordinates> UseCurrentGeolocation()
        {
            return await module.InvokeAsync<GeoLocationCoordinates>("useCurrentGeolocationAsync");
        }
            

        public async ValueTask<GeolocationResult> GetCurrentPosition(PositionOptions options = null)
        {
            // var module = await _jsBinder.GetModule();
            return await module.InvokeAsync<GeolocationResult>("Geolocation.getCurrentPosition", options);
        }

        public async ValueTask DisposeAsync()
        {
            if (module is not null)
            {
                await module.DisposeAsync();
            }
        }
    }

    public class GeoLocationCoordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class GeolocationPosition
    {
        /// <summary>
        /// The coordinates defining the current location
        /// </summary>
        public GeolocationCoordinates Coords { get; set; }

        /// <summary>
        /// The time the coordinates were taken, in milliseconds since the Unix epoch.
        /// </summary>
        public long Timestamp { get; set; }

        /// <summary>
        /// The <see cref="DateTimeOffset"/> derived from the <see cref="Timestamp"/>, in UTC.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset DateTimeOffset => DateTimeOffset.FromUnixTimeMilliseconds(Timestamp);
    }

    public class GeolocationResult
    {
        /// <summary>
        /// The <see cref="GeolocationPosition"/> returned on successful geolocation.
        /// </summary>
        public GeolocationPosition Position { get; set; }
        /// <summary>
        /// The <see cref="GeolocationPositionError"/> returned by a failed geolocation attempt.
        /// </summary>
        public GeolocationPositionError Error { get; set; }

        /// <summary>
        /// Indicates whether the geolocation attempt was successful.
        /// </summary>
        [JsonIgnore]
        public bool IsSuccess => !(Position is null);
    }

    public enum GeolocationPositionErrorCode
    {
        /// <summary>
        /// Geolocation failoed because the device does not support geolocation. Not part of W3C spec.
        /// </summary>
        DEVICE_NOT_SUPPORTED = 0,
        /// <summary>
        /// Geolocation failed because permission to access location was denied.
        /// </summary>
        PERMISSION_DENIED = 1,
        /// <summary>
        /// Geolocation failed because of an internal error on the device.
        /// </summary>
        POSITION_UNAVAILABLE = 2,
        /// <summary>
        /// Geolocation failed because no position was returned in time.
        /// </summary>
        TIMEOUT = 3
    }

    public class GeolocationPositionError
    {
        /// <summary>
        /// The <see cref="GeolocationPositionErrorCode"/> for the error.
        /// </summary>
        public GeolocationPositionErrorCode Code { get; set; }

        /// <summary>
        /// Details of the error. Intended for debugging rather than display to the user.
        /// </summary>
        public string Message { get; set; }
    }

    public class GeolocationCoordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? Altitude { get; set; }
        public double Accuracy { get; set; }
        public double? AltitudeAccuracy { get; set; }
        public double? Heading { get; set; }
        public double? Speed { get; set; }
    }

    public class PositionOptions
    {
        /// <summary>
        /// Enable high accuracy mode for best possible results.
        /// May be slower or increase power consumption. Defaults to false.
        /// </summary>
        public bool EnableHighAccuracy { get; set; } = false;

        /// <summary>
        /// Maximum length of time allowed to return a position (in milliseconds).
        /// Set to null for no timeout. Defaults to null.
        /// </summary>
        public long? Timeout { get; set; } = null;

        /// <summary>
        /// Maximum allowed age for a cached result.
        /// Set to null to disregard the age of cached results.
        /// Set to 0 to skip the cache and attempt a fresh result every time. Defaults to 0.
        /// </summary>
        public long? MaximumAge { get; set; } = 0;
    }
}
