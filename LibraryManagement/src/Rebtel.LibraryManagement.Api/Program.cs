using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rebtel.LibraryManagement.Api.Extensions;
using Rebtel.LibraryManagement.Contracts;
using Rebtel.LibraryManagement.DTOs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAPIServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                $"Library Management API {description.GroupName.ToUpperInvariant()}");
        }
    });
}

// Add global exception handling
app.UseExceptionHandler();

app.UseHttpsRedirection();

// Create version set for v1 only
var versionSet = app.NewApiVersionSet()
    .HasApiVersion(new ApiVersion(1, 0))
    .ReportApiVersions()
    .Build();

// Books API Endpoints - V1
var booksV1 = app.MapGroup("/api/v{version:apiVersion}/books")
    .WithApiVersionSet(versionSet)
    .MapToApiVersion(1, 0)
    .WithTags("Books");

booksV1.MapGet("/mostborrowed", async ([FromServices] BooksService.BooksServiceClient client, [FromServices] IMapper mapper, [FromQuery] int count = 3) =>
{
    var response = await client.GetMostBorrowedBooksAsync(new GetMostBorrowedBooksRequest { Count = count });
    return TypedResults.Ok(mapper.Map<IEnumerable<BookDTO>>(response.Books));
})
.WithName("GetMostBorrowedBooksV1")
.WithOpenApi()
.WithSummary("Get the most borrowed books")
.WithDescription("Retrieves the most borrowed books based on the specified count")
.Produces<IEnumerable<BookDTO>>(StatusCodes.Status200OK)
.ProducesProblem(StatusCodes.Status400BadRequest);

booksV1.MapGet("/{bookId}/commonborrowed", async ([FromServices] BooksService.BooksServiceClient client, [FromServices] IMapper mapper, Guid bookId, [FromQuery] int count = 3) =>
{
    var response = await client.GetCommonBorrowedBooksAsync(new GetCommonBorrowedBooksRequest { BookId = bookId.ToString(), Count = count });
    return TypedResults.Ok(mapper.Map<IEnumerable<BookDTO>>(response.Books));
})
.WithName("GetCommonBorrowedBooksV1")
.WithOpenApi()
.WithSummary("Get books commonly borrowed with a specific book")
.WithDescription("Retrieves books that are commonly borrowed together with the specified book")
.Produces<IEnumerable<BookDTO>>(StatusCodes.Status200OK)
.ProducesProblem(StatusCodes.Status400BadRequest)
.ProducesProblem(StatusCodes.Status404NotFound);

// Users API Endpoints - V1
var usersV1 = app.MapGroup("/api/v{version:apiVersion}/users")
    .WithApiVersionSet(versionSet)
    .MapToApiVersion(1, 0)
    .WithTags("Users");

usersV1.MapGet("/mostborrowing", async ([FromServices] UsersService.UsersServiceClient client, [FromServices] IMapper mapper, [FromQuery] DateTime startTime, [FromQuery] DateTime endTime, [FromQuery] int count = 3) =>
{
    var response = await client.GetMostBorrowingUsersAsync(new GetMostBorrowingUsersRequest
    {
        StartTime = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(startTime.ToUniversalTime()),
        EndTime = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(endTime.ToUniversalTime()),
        Count = count
    });
    return TypedResults.Ok(mapper.Map<IEnumerable<UserDTO>>(response.Users));
})
.WithName("GetMostBorrowingUsersV1")
.WithOpenApi()
.WithSummary("Get the most borrowing users within a date range")
.WithDescription("Retrieves users who borrowed the most books within the specified date range")
.Produces<IEnumerable<UserDTO>>(StatusCodes.Status200OK)
.ProducesProblem(StatusCodes.Status400BadRequest);

usersV1.MapGet("/{userId}/readingpace", async ([FromServices] UsersService.UsersServiceClient client, Guid userId, [FromQuery] Guid bookId) =>
{
    var response = await client.GetUserReadingPaceAsync(new GetUserReadingPaceRequest { UserId = userId.ToString(),BookId = bookId.ToString() });
    return TypedResults.Ok(new { Pace = response.Pace });
})
.WithName("GetUserReadingPaceV1")
.WithOpenApi()
.WithSummary("Get reading pace for a specific user")
.WithDescription("Retrieves the reading pace (pages per day) for a specific user")
.Produces<object>(StatusCodes.Status200OK)
.ProducesProblem(StatusCodes.Status400BadRequest)
.ProducesProblem(StatusCodes.Status404NotFound);

//Health Endpoints for K8s (version-agnostic)
app.MapHealthChecks("/health").WithName("health");
app.MapHealthChecks("/ready").WithName("ready");
app.MapHealthChecks("/startup").WithName("startup");

app.Run();

// Make Program class accessible to test projects
public partial class Program { }
