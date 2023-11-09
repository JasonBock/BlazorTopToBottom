using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;

namespace BlazingCollatz.WebComponents.Extensions;

public static class IServiceCollectionExtensions 
{
   public static void AddWebComponents(this IServiceCollection self) => 
		self.AddBlazoredLocalStorage();
}