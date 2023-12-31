using AdessibindenFrontend;
using AdessibindenFrontend.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddAPIServices();

builder.Services.AddScoped<StatusCodeDelegatingHandler>();
builder.Services.AddScoped<CookieHandler>();

//httpclient yerine restsharp!!! *********************************************************************************************************************************************
builder.Services.AddScoped(sp =>
{
    IHttpClientFactory httpClientFactory = sp.GetService<IHttpClientFactory>();
    var httpClient = httpClientFactory.CreateClient("StatusCodeDelegatingHandler");
    httpClient.BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAPIUrl"));
    return httpClient;
}).AddHttpClient("StatusCodeDelegatingHandler", client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
}).AddHttpMessageHandler<StatusCodeDelegatingHandler>().AddHttpMessageHandler<CookieHandler>();



builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
