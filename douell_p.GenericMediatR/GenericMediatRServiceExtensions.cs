using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace douell_p.GenericMediatR
{
    public static class GenericMediatRServiceExtensions
    {
        public static IServiceCollection AddGenericMediatR
            (this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddMediatR(typeof(GenericMediatRServiceExtensions).Assembly);
            services.AddAutoMapper(typeof(GenericMediatRServiceExtensions).Assembly);
            
            IncludedGenericMediatREntities.Assemblies = assemblies;

            return services;
        }
    }
}