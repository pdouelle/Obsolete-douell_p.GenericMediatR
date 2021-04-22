using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace douell_p.GenericMediatR
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGenericMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceCollectionExtensions));

            return services;
        }
    }
}