using Kingdoms.Fluent.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using Serilog;
using Serilog.Events;

internal class Program
{
    private static WebApplicationBuilder? _builder;

    private static void Main(string[] args)
    {
        _builder = WebApplication.CreateBuilder(args);

        InitialiseLogger();
        InitialiseServices();

        var app = _builder.Build();

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

    /// <summary>
    /// Add services to the container.
    /// </summary>
    private static void InitialiseServices()
    {
        if (_builder is null) throw new InvalidOperationException("The WebApplicationBuilder is not initialised.");
        _builder.Services.AddRazorComponents().AddInteractiveServerComponents();
        _builder.Services.AddFluentUIComponents();
    }

    private static void InitialiseLogger()
    {
        if (_builder is null) throw new InvalidOperationException("The WebApplicationBuilder is not initialised.");
        _builder.Host.UseSerilog((context, logger) => {
            logger.MinimumLevel.Is(LogEventLevel.Debug)
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information) // Filter specific namespace
            .MinimumLevel.Override("MudBlazor", LogEventLevel.Information) // Filter specific namespace
            .WriteTo.File(AppDomain.CurrentDomain.BaseDirectory + "/logs/log.json", rollingInterval: RollingInterval.Day, shared: true)
            .WriteTo.Console();
        });
        Log.Debug("Logger: Initialised.");
    }
}