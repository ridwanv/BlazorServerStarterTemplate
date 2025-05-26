using CleanArchitecture.Blazor.Application;
using CleanArchitecture.Blazor.Application.Services;
using CleanArchitecture.Blazor.Infrastructure;
using CleanArchitecture.Blazor.Server.UI;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterSerilog();
builder.WebHost.UseStaticWebAssets();

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddServerUI(builder.Configuration);

// Ensure the AddApplicationServices extension method is defined and accessible.
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

app.ConfigureServer(builder.Configuration);

await app.InitializeDatabaseAsync().ConfigureAwait(false);

await app.RunAsync().ConfigureAwait(false);