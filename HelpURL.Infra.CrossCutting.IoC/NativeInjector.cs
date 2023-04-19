using HelpURL.Application.Interfaces;
using HelpURL.Application.Services;
using HelpURL.Domain.Interfaces;
using HelpURL.Infra.Data.Context;
using HelpURL.Infra.Data.Repositories;
using HelpURL.Infra.Data.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace HelpURL.Infra.CrossCutting.IoC;

public static class NativeInjector
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.RegisterInfraDependencyInjection();
        services.RegisterApplicationDependencyInjection();

    }
    public static void RegisterApplicationDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IURLService, URLServices>();
    }

    public static void RegisterInfraDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<HelpURLContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IURLRepository, URLRepository>();
    }
}
