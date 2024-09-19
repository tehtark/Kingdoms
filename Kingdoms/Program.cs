using Auth0.AspNetCore.Authentication;
using Kingdoms.Application;
using Kingdoms.Components;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MudBlazor.Services;
using Serilog;
using Serilog.Events;

internal class Program
{
    private static WebApplicationBuilder _builder;
    private static WebApplication _app;

    private static void Main(string[] args)
    {
        _builder = WebApplication.CreateBuilder(args);

        InitialiseLogger();

        _builder.Services.AddAuth0WebAppAuthentication(options => {
            options.Domain = Environment.GetEnvironmentVariable("AUTH_DOMAIN");
            options.ClientId = Environment.GetEnvironmentVariable("AUTH_CLIENT_ID");
        });

        // Add MudBlazor services
        _builder.Services.AddMudServices();

        // Add services to the container.
        _builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        _builder.Services.AddApplication();

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

        _app.MapGet("/Account/Login", async (HttpContext httpContext, string redirectUri = "/") => {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder().WithRedirectUri(redirectUri).Build();
            await httpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        });

        _app.MapGet("/Account/Logout", async (HttpContext httpContext, string redirectUri = "/") => {
            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder().WithRedirectUri(redirectUri).Build();
            await httpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        });

        _app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        _app.Run();
    }

    private static void InitialiseLogger()
    {
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