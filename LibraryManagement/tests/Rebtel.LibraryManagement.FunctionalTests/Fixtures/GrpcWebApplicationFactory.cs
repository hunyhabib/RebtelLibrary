extern alias GrpcProject;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rebtel.LibraryManagement.Infrastructure;
using Testcontainers.MsSql;

namespace Rebtel.LibraryManagement.FunctionalTests.Fixtures;

/// <summary>
/// WebApplicationFactory for the GRPC server used in functional tests.
/// This factory manages the lifecycle of the GRPC server and provides database configuration.
/// The GRPC server is configured to use port 5999 to avoid conflicts with the API server.
/// </summary>
public class GrpcWebApplicationFactory : WebApplicationFactory<GrpcProject::Program>, IAsyncLifetime
{
    private readonly MsSqlContainer _dbContainer = new MsSqlBuilder()
        .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
        .WithPassword("FunctionalTest123!")
        .WithCleanUp(true)
        .Build();
    
    /// <summary>
    /// Gets the GRPC server address
    /// </summary>
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // Configure the GRPC server to use a specific port to avoid conflicts
        builder.ConfigureServices(services =>
        {
            // Remove the existing DbContext registrations
            var dbContextDescriptor = services.SingleOrDefault(
              d => d.ServiceType == typeof(DbContextOptions<LibraryManagementContext>));

            if (dbContextDescriptor != null)
            {
                services.Remove(dbContextDescriptor);
            }

            var dbContextServiceDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(LibraryManagementContext));

            if (dbContextServiceDescriptor != null)
            {
                services.Remove(dbContextServiceDescriptor);
            }

            // Add SQL Server test container database
            services.AddDbContext<LibraryManagementContext>(options =>
                options.UseSqlServer(_dbContainer.GetConnectionString()));
        });
    }

    /// <summary>
    /// Initializes the GRPC server and applies database migrations
    /// </summary>
    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
    }

    /// <summary>
    /// Disposes of the GRPC server resources
    /// </summary>
    public new async Task DisposeAsync()
    {
        await _dbContainer.StopAsync();
        await _dbContainer.DisposeAsync();
        await base.DisposeAsync();
    }
}
