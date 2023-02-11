using Blazored.LocalStorage;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace BlazingCollatz.WebComponents.Extensions;

public static class IServiceCollectionExtensions 
{
	public static void AddWebComponents(this IServiceCollection @this)
	{
		@this.AddTransient<SequenceViewModel>();
		@this.AddSingleton(services =>
		{
			var httpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));
			var channel = GrpcChannel.ForAddress("https://localhost:3113", new GrpcChannelOptions { HttpClient = httpClient });
			return new CollatzGrpc.Collatz.CollatzClient(channel);
		});
		@this.AddBlazoredLocalStorage();
	}
}