using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalPlane.ConferenceProject.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
        services
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddMediatR(Assembly.GetExecutingAssembly());
}