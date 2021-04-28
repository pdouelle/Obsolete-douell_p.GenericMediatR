using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace douell_p.GenericMediatR
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGenericMediatR
            (this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);
            services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
            
            IncludedEntities.Assemblies = assemblies;

            return services;
        }
    }
}