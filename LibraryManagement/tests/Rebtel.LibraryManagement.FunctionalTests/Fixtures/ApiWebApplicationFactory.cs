extern alias ApiProject;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Rebtel.LibraryManagement.Contracts;

namespace Rebtel.LibraryManagement.FunctionalTests.Fixtures;

/// <summary>
/// WebApplicationFactory for the API project used in functional tests.
/// This factory orchestrates both the API and GRPC servers for end-to-end testing,
/// ensuring proper communication between the API layer and GRPC services.
/// </summary>
public class ApiWebApplicationFactory : WebApplicationFactory<ApiProject::Program>, IAsyncLifetime
{

    private GrpcWebApplicationFactory grpcFactory;

    /// <summary>
    /// Configures the web host for testing by setting up test database and GRPC server configuration
    /// </summary>
    /// <param name="builder">The web host builder to configure</param>
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            // Additional test-specific service configuration can go here
            // Add GRPC clients that use the test server's HttpMessageHandler
            services.AddGrpcClient<BooksService.BooksServiceClient>(o =>
            {
                o.Address = grpcFactory.Server.BaseAddress;
            }).ConfigurePrimaryHttpMessageHandler(() => grpcFactory.Server.CreateHandler());

            services.AddGrpcClient<UsersService.UsersServiceClient>(o =>
            {
                o.Address = grpcFactory.Server.BaseAddress;
            }).ConfigurePrimaryHttpMessageHandler(() => grpcFactory.Server.CreateHandler());
        });
    }

    /// <summary>
    /// Initializes the test environment by starting the GRPC server
    /// </summary>
    public async Task InitializeAsync()
    {
        // Create and initialize the GRPC server
        grpcFactory = new GrpcWebApplicationFactory();
        await grpcFactory.InitializeAsync();
        grpcFactory.CreateClient();
    }

    /// <summary>
    /// Disposes of all test resources including GRPC server and database container
    /// </summary>
    public new async Task DisposeAsync()
    {
        if (grpcFactory != null)
        {
            await grpcFactory.DisposeAsync();
        }


    }
}
