using HymnCenter.Client;
using HymnCenter.Client.Services;
using HymnCenter.Client.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IHymnService, HymnService>();
builder.Services.AddScoped<IListingService, ListingService>();
builder.Services.AddScoped<IAlertService, AlertService>();
builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IHymnCategoryService, HymnCategoryService>();
builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped(x => {
    var apiUrl = new Uri("http://localhost:5001");
    return new HttpClient() { BaseAddress = apiUrl };
});
builder.Services.AddSingleton<PageHistoryState>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
