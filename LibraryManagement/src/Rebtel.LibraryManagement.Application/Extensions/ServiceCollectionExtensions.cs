using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rebtel.LibraryManagement.Application.Behaviors;

namespace Rebtel.LibraryManagement.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application services here
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddAutoMapper(t => t.AddMaps(typeof(ServiceCollectionExtensions).Assembly));
            services.AddValidatorsFromAssemblyContaining(typeof(ServiceCollectionExtensions), includeInternalTypes: true);
            return services;
        }
    }
}
