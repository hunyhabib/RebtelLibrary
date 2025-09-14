using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Rebtel.LibraryManagement.Infrastructure.Extensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder MigrateDatabaseOnStartup(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var dataContext = scope.ServiceProvider.GetRequiredService<LibraryManagementContext>();
            dataContext.Database.Migrate();
            dataContext.Database.EnsureCreated();

            return app;
        }
    }
}
