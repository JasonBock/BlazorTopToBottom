using DataAccess;
using DataAccess.Components;
using DataAccess.Dal;
using DataAccess.Dal.Mock;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddTransient<RenderModeProvider>();
builder.Services.AddScoped<ActiveCircuitState>();
builder.Services.AddScoped(typeof(CircuitHandler), typeof(ActiveCircuitHandler));

builder.Services.AddSingleton<IDataAccess, MockDataAccess>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(DataAccess.Client._Imports).Assembly);

app.MapPost("/api/SaveData", 
    ([FromServices] IDataAccess dal, [FromBody] PersonEntity data) =>
{
    dal.SavePerson(data);
    return Results.Ok();
});

app.MapGet("/api/GetData", ([FromServices] IDataAccess dal, [FromQuery] int id) =>
{
    var data = dal.GetPersonById(id);
    return data;
});

app.Run();
