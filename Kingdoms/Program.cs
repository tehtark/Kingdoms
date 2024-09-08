using Kingdoms.Components;
using MudBlazor.Services;
using Serilog;
using Serilog.Events;
using Kingdoms.Application;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        InitialiseLogger(builder.Host);

        // Add MudBlazor services
        builder.Services.AddMudServices();

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddApplication();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment()) {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }

    private static void InitialiseLogger(IHostBuilder host)
    {
        host.UseSerilog((context, logger) => {
            logger.MinimumLevel.Is(LogEventLevel.Debug)
            .WriteTo.File(AppDomain.CurrentDomain.BaseDirectory + "/logs/log.json", rollingInterval: RollingInterval.Day, shared: true)
            .WriteTo.Console();
        });

        Log.Debug("Logger: Initialised.");
    }
}