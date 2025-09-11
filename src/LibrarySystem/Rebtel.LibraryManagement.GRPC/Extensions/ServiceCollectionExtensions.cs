using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Rebtel.LibraryManagement.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services)
        {
            // Register application services here
            services.AddGrpc();
            services.AddRebtelOpenTelemetry();
            services.AddHealthChecks();

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
}
