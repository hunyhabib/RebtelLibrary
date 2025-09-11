using Microsoft.EntityFrameworkCore;
using Rebtel.LibraryManagement.Api.Extensions;
using Rebtel.LibraryManagement.Application.Extensions;
using Rebtel.LibraryManagement.GRPC.Services;
using Rebtel.LibraryManagement.Infrastructure;
using Rebtel.LibraryManagement.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAPIServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<LibraryManagementContext>();
    dataContext.Database.Migrate();
    dataContext.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
app.MapGrpcService<BooksService>();

//Helth Endpoints for K8s
app.MapHealthChecks("/health").WithName("health");
app.MapHealthChecks("/ready").WithName("ready");
app.MapHealthChecks("/startup").WithName("startup");

app.Run();
