using Auth0.AspNetCore.Authentication;
using Kingdoms.Fluent.Components;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.FluentUI.AspNetCore.Components;
using Serilog;
using Serilog.Events;
using Kingdoms.Application;

internal class Program
{
    private static WebApplicationBuilder? _builder;
    private static WebApplication? _app;

    private static void Main(string[] args)
    {
        _builder = WebApplication.CreateBuilder(args);

        InitialiseLogger();
        InitialiseServices();

        _app = _builder.Build();

        // Configure the HTTP request pipeline.
        if (!_app.Environment.IsDevelopment()) {
            _app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            _app.UseHsts();
        }

        _app.UseHttpsRedirection();

        _app.UseStaticFiles();
        _app.UseAntiforgery();

        MapComponents();

        _app.Run();
    }

    /// <summary>
    /// Add services to the container.
    /// </summary>
    private static void InitialiseServices()
    {
        if (_builder is null) throw new InvalidOperationException("The WebApplicationBuilder is not initialised.");

        // Default services
        _builder.Services.AddRazorComponents().AddInteractiveServerComponents();
        _builder.Services.AddFluentUIComponents();
        _builder.Services.AddDataGridEntityFrameworkAdapter();

        // Auth0 services
        _builder.Services.AddAuth0WebAppAuthentication(options => {
            options.Domain = Environment.GetEnvironmentVariable("AUTH_DOMAIN");
            options.ClientId = Environment.GetEnvironmentVariable("AUTH_CLIENT_ID");
        });

        // Application Layer services
        _builder.Services.AddApplication();
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

    private static void MapComponents()
    {
        if (_app is null) throw new InvalidOperationException("The WebApplication is not initialised.");

        // Default components
        _app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        // Auth0 components
        _app.MapGet("/Account/Login", async (HttpContext httpContext, string redirectUri = "/") => {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder().WithRedirectUri(redirectUri).Build();
            await httpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        });

        _app.MapGet("/Account/Logout", async (HttpContext httpContext, string redirectUri = "/") => {
            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder().WithRedirectUri(redirectUri).Build();
            await httpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        });
    }
}