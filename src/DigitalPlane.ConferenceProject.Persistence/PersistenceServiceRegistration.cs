using DigitalPlane.ConferenceProject.Application.Contracts.Persistence;
using DigitalPlane.ConferenceProject.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalPlane.ConferenceProject.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration, string connectionStringSection, string migrationAssemblyName) =>
        services
            .AddDatabase(configuration, connectionStringSection, migrationAssemblyName)
            .AddRepositories();

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration,
        string connectionStringSection, string migrationAssemblyName) =>
        services.AddDbContext<ConferenceProjectDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString(connectionStringSection),
                b => b.MigrationsAssembly(migrationAssemblyName)));

    private static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services
            .AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>))
            .AddScoped<IConferenceRepository, ConferenceRepository>()
            .AddScoped<IProposalRepository, ProposalRepository>();
}