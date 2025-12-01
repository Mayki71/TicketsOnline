using Blazored.LocalStorage;
using FrontendTicketsOnline;
using FrontendTicketsOnline.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// HttpClient global
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7042/")
});

// HttpClient para consumir la API
builder.Services.AddScoped<ApiHttpClient>();

// Registrar Blazored.LocalStorage
builder.Services.AddBlazoredLocalStorage();

// Registrar servicios
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IConciertoService, ConciertoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ICarritoService, CarritoService>();

await builder.Build().RunAsync();
