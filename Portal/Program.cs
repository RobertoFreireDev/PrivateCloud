var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddScoped(sp =>
{
    var navManager = sp.GetRequiredService<NavigationManager>();
    var uriBuilder = new UriBuilder(navManager.BaseUri)
    {
        Port = 3000
    };
    return new HttpClient { BaseAddress = uriBuilder.Uri };
});

await builder.Build().RunAsync();
