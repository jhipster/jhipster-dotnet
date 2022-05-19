using JHipster.NetLite.Application.Services;
using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Repositories.Interfaces;
using JHipster.NetLite.Domain.Services;
using JHipster.NetLite.Domain.Services.Interfaces;
using JHipster.NetLite.Infrastructure.Repositories;
using JHipster.NetLite.Web.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace JHipster.NetLite.Web;

public static class ServiceCollectionExtensions
{
    private const string JhipsterLite = "JhipsterNetLite";

    public static IMvcBuilder AddJHipsterLite(this IMvcBuilder builder)
    {
        builder.AddControllersAsServices().AddApplicationPart(JHipsterLiteConstantes.WebAssembly).AddControllersAsServices();
        builder.Services.AddAutoMapper(JHipsterLiteConstantes.WebAssembly);
        builder.Services.AddJHipsterLiteApplicationServices()
                          .AddJHipsterLiteDomainServices()
                          .AddJHipsterLiteRepositories();

        using var loggerFactory = LoggerFactory.Create(loggingBuilder => loggingBuilder
            .SetMinimumLevel(LogLevel.Trace)
            .AddConsole());

        ILogger logger = loggerFactory.CreateLogger(JhipsterLite);
        LogAssciText(logger);

        return builder;
    }

    private static IServiceCollection AddJHipsterLiteApplicationServices(this IServiceCollection services)
    {
        return services.AddScoped<IInitApplicationService, InitApplicationService>()
                .AddScoped<IApiApplicationService, ApiApplicationService>()
                .AddScoped<IGithubActionApplicationService, GithubActionApplicationService>()
                .AddScoped<ISonarApplicationService, SonarApplicationService>()
                .AddScoped<IBlazorApplicationService, BlazorApplicationService>();
    }

    private static IServiceCollection AddJHipsterLiteDomainServices(this IServiceCollection services)
    {
        return services.AddScoped<IInitDomainService, InitDomainService>()
                .AddScoped<IApiDomainService, ApiDomainService>()
                .AddScoped<IGithubActionDomainService, GithubActionDomainService>()
                .AddScoped<ISonarDomainService, SonarDomainService>()
                .AddScoped<IBlazorDomainService, BlazorDomainService>();
    }

    private static IServiceCollection AddJHipsterLiteRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProjectRepository, ProjectLocalRepository>();
        return services;
    }

    private static void LogAssciText(ILogger logger)
    {
        logger.LogInformation(@$"  
  {AnsiColor.GREEN}      ██╗{AnsiColor.RED} ██╗   ██╗ ████████╗ ███████╗   ██████╗ ████████╗ ████████╗ ███████╗ {AnsiColor.MAGENTA}   ███╗   ██╗███████╗████████╗
  {AnsiColor.GREEN}      ██║{AnsiColor.RED} ██║   ██║ ╚══██╔══╝ ██╔═══██╗ ██╔════╝ ╚══██╔══╝ ██╔═════╝ ██╔═══██╗{AnsiColor.MAGENTA}   ████╗  ██║██╔════╝╚══██╔══╝
  {AnsiColor.GREEN}      ██║{AnsiColor.RED} ████████║    ██║    ███████╔╝ ╚█████╗     ██║    ██████╗   ███████╔╝{AnsiColor.MAGENTA}   ██╔██╗ ██║█████╗     ██║   
  {AnsiColor.GREEN}██╗   ██║{AnsiColor.RED} ██╔═══██║    ██║    ██╔════╝   ╚═══██╗    ██║    ██╔═══╝   ██╔══██║ {AnsiColor.MAGENTA}   ██║╚██╗██║██╔══╝     ██║   
  {AnsiColor.GREEN}╚██████╔╝{AnsiColor.RED} ██║   ██║ ████████╗ ██║       ██████╔╝    ██║    ████████╗ ██║  ╚██╗{AnsiColor.MAGENTA}██╗██║ ╚████║███████╗   ██║   
  {AnsiColor.GREEN} ╚═════╝ {AnsiColor.RED} ╚═╝   ╚═╝ ╚═══════╝ ╚═╝       ╚═════╝     ╚═╝    ╚═══════╝ ╚═╝   ╚═╝{AnsiColor.MAGENTA}╚═╝╚═╝  ╚═══╝╚══════╝   ╚═╝   
  {AnsiColor.WHITE}█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
  {AnsiColor.BRIGHT_BLUE}:: JHipster.Net 🤓  :: Running ASP.Net Core 'The best version' ::
:: http://jhipster.github.io ::{AnsiColor.DEFAULT}");
    }
}
