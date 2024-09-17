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
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        InitialiseLogger(builder.Host);

        builder.Services.AddAuth0WebAppAuthentication(options => {
            options.Domain = Environment.GetEnvironmentVariable("AUTH_DOMAIN");
            options.ClientId = Environment.GetEnvironmentVariable("AUTH_CLIENT_ID");
        });

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

        app.MapGet("/Account/Login", async (HttpContext httpContext, string redirectUri = "/") => {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder().WithRedirectUri(redirectUri).Build();
            await httpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        });

        app.MapGet("/Account/Logout", async (HttpContext httpContext, string redirectUri = "/") => {
            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder().WithRedirectUri(redirectUri).Build();
            await httpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        });

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