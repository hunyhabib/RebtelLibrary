using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;
using Rebtel.LibraryManagement.Api.ExceptionHandlers;
using Rebtel.LibraryManagement.Api.Profiles;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Rebtel.LibraryManagement.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the API services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register application services here
            services.AddGrpc();
            services.AddAutoMapper(t => t.AddMaps(typeof(ProtoToDtoProfile).Assembly));
            services.AddRebtelOpenTelemetry();
            services.AddHealthChecks();
            services.AddProblemDetails();
            services.AddEndpointsApiExplorer();
            
            // Add exception handlers
            services.AddExceptionHandler<GrpcExceptionHandler>();
            
            // Add API versioning
            services.AddApiVersioning(opt =>
            {
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddMvc()
            .AddApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });
            
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen();
            
            services.AddGrpcClient<Contracts.BooksService.BooksServiceClient>(o =>
            {
                o.Address = new Uri(configuration["LibraryApiUrl"]!); 
            });

            services.AddGrpcClient<Contracts.UsersService.UsersServiceClient>(o =>
            {
                o.Address = new Uri(configuration["LibraryApiUrl"]!);
            });

            return services;
        }


        /// <summary>
        /// Adds the open telemetry.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        private static IServiceCollection AddRebtelOpenTelemetry(this IServiceCollection services)
        {
            var otel = services.AddOpenTelemetry();

            otel.WithMetrics(metrics => metrics
                .AddAspNetCoreInstrumentation()
                .AddMeter("Microsoft.AspNetCore.Hosting")
                .AddMeter("Microsoft.AspNetCore.Server.Kestrel")
                .AddMeter("System.Net.Http")
                .AddMeter("System.Net.NameResolution"));

            // Add Tracing for ASP.NET Core and our custom ActivitySource and export to Jaeger
            otel.WithTracing(tracing =>
            {
                tracing.AddAspNetCoreInstrumentation();
                tracing.AddHttpClientInstrumentation();
                tracing.AddConsoleExporter();
            });
            return services;
        }

    }

    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        private static Microsoft.OpenApi.Models.OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new Microsoft.OpenApi.Models.OpenApiInfo()
            {
                Title = "Library Management API",
                Version = description.ApiVersion.ToString(),
                Description = "A Library Management API for managing books and users",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = "Library Management Team",
                    Email = "support@rebtel.com"
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += " - This API version has been deprecated.";
            }

            return info;
        }
    }
}
