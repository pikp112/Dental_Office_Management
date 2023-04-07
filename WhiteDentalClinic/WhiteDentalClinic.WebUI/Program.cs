using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WhiteDentalClinic.WebUI;
using Syncfusion.Blazor;
using MudBlazor.Services;
using MudBlazor;
using Blazored.Toast;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7093") });

builder.Services.AddMudServices();  //MudBlazor
builder.Services.AddBlazoredToast(); //toast


builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();