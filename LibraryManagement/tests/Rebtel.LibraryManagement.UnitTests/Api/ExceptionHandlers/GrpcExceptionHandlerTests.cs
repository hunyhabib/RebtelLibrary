using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Rebtel.LibraryManagement.Api.ExceptionHandlers;
using System.Text.Json;

namespace Rebtel.LibraryManagement.UnitTests.Api.ExceptionHandlers;

public class GrpcExceptionHandlerTests
{
    private readonly Mock<ILogger<GrpcExceptionHandler>> _loggerMock;
    private readonly GrpcExceptionHandler _handler;

    public GrpcExceptionHandlerTests()
    {
        _loggerMock = new Mock<ILogger<GrpcExceptionHandler>>();
        _handler = new GrpcExceptionHandler(_loggerMock.Object);
    }

    [Fact]
    public async Task TryHandleAsync_WhenNotRpcException_ShouldReturnFalse()
    {
        // Arrange
        var context = new DefaultHttpContext();
        var exception = new InvalidOperationException("Test exception");

        // Act
        var result = await _handler.TryHandleAsync(context, exception, CancellationToken.None);

        // Assert
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData(StatusCode.InvalidArgument, 400, "Invalid Request")]
    [InlineData(StatusCode.NotFound, 404, "Resource Not Found")]
    [InlineData(StatusCode.Unauthenticated, 401, "Authentication Required")]
    [InlineData(StatusCode.PermissionDenied, 403, "Permission Denied")]
    [InlineData(StatusCode.Internal, 500, "Internal Server Error")]
    public async Task TryHandleAsync_WhenRpcException_ShouldReturnTrueAndWriteResponse(StatusCode grpcStatus, int expectedHttpStatus, string expectedTitle)
    {
        // Arrange
        var context = new DefaultHttpContext();
        context.Response.Body = new MemoryStream();
        
        var rpcException = new RpcException(new Status(grpcStatus, "Test error detail"));

        // Act
        var result = await _handler.TryHandleAsync(context, rpcException, CancellationToken.None);

        // Assert
        result.Should().BeTrue();
        context.Response.StatusCode.Should().Be(expectedHttpStatus);

        context.Response.Body.Position = 0;
        var responseBody = await new StreamReader(context.Response.Body).ReadToEndAsync();
        
        var jsonDocument = JsonDocument.Parse(responseBody);
        jsonDocument.RootElement.GetProperty("status").GetInt32().Should().Be(expectedHttpStatus);
        jsonDocument.RootElement.GetProperty("title").GetString().Should().Be(expectedTitle);
        jsonDocument.RootElement.GetProperty("detail").GetString().Should().Be("Test error detail");
    }

    [Fact]
    public async Task TryHandleAsync_WhenRpcException_ShouldLogWarning()
    {
        // Arrange
        var context = new DefaultHttpContext();
        context.Response.Body = new MemoryStream();
        
        var rpcException = new RpcException(new Status(StatusCode.InvalidArgument, "Validation failed"));

        // Act
        await _handler.TryHandleAsync(context, rpcException, CancellationToken.None);

        // Assert
        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("gRPC exception occurred")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }
}
