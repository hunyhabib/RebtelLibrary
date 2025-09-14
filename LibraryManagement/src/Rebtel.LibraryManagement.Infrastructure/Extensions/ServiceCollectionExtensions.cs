using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rebtel.LibraryManagement.Domain.Repositories;
using Rebtel.LibraryManagement.Infrastructure.Repositories;

namespace Rebtel.LibraryManagement.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<LibraryManagementContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LibraryManagementDB")));

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<ILoanRepository, LoansRepository>();
            return services;
        }
    }
}
