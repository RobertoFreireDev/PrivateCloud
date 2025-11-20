var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var appSettings = builder.Configuration.Get<AppSettings>();

builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(
        appSettings.IsLocal ? appSettings.LocalApiBaseUrl : appSettings.ApiBaseUrl
    ) });

await builder.Build().RunAsync();
