using Rebtel.LibraryManagement.GRPC.Extensions;
using Rebtel.LibraryManagement.Application.Extensions;
using Rebtel.LibraryManagement.GRPC.Services;
using Rebtel.LibraryManagement.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAPIServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.MigrateDatabaseOnStartup();

// Configure the HTTP request pipeline.
app.MapGrpcService<BooksService>();
app.MapGrpcService<UsersService>();

//Health Endpoints for K8s
app.MapHealthChecks("/health").WithName("health");
app.MapHealthChecks("/ready").WithName("ready");
app.MapHealthChecks("/startup").WithName("startup");

app.Run();

// Make the implicit Program class public so test projects can access it
public partial class Program { }
