using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using pokemon_portal_blazor;
using pokemon_portal_blazor.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{builder.HostEnvironment.Environment}.json", optional: true);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["API_BASE_URL"]!) });
builder.Services.AddServices();

builder.Services.AddBlazorBootstrap();


await builder.Build().RunAsync();
