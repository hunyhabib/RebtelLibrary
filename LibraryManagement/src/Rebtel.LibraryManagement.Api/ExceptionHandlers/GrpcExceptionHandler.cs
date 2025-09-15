using Grpc.Core;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Rebtel.LibraryManagement.Api.ExceptionHandlers;

/// <summary>
/// Exception handler to handle gRPC exceptions and HTTP request exceptions, converting them to appropriate HTTP responses with ProblemDetails
/// </summary>
public class GrpcExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GrpcExceptionHandler> _logger;

    public GrpcExceptionHandler(ILogger<GrpcExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        return exception switch
        {
            RpcException rpcException => await HandleRpcExceptionAsync(httpContext, rpcException, cancellationToken),
            BadHttpRequestException badHttpException => await HandleBadHttpRequestExceptionAsync(httpContext, badHttpException, cancellationToken),
            _ => false
        };
    }

    /// <summary>
    /// Handles the RPC exception asynchronous.
    /// </summary>
    /// <param name="httpContext">The HTTP context.</param>
    /// <param name="rpcException">The RPC exception.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    private async ValueTask<bool> HandleRpcExceptionAsync(HttpContext httpContext, RpcException rpcException, CancellationToken cancellationToken)
    {
        _logger.LogWarning(rpcException, "gRPC exception occurred: {StatusCode} - {Detail}",
            rpcException.StatusCode, rpcException.Status.Detail);

        var (httpStatusCode, title) = MapGrpcStatusToHttp(rpcException.StatusCode);

        var problemDetails = new ProblemDetails
        {
            Status = (int)httpStatusCode,
            Title = title,
            Detail = rpcException.Status.Detail,
            Instance = httpContext.Request.Path,
        };

        httpContext.Response.StatusCode = (int)httpStatusCode;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    /// <summary>
    /// Handles the bad HTTP request exception asynchronous.
    /// </summary>
    /// <param name="httpContext">The HTTP context.</param>
    /// <param name="badHttpException">The bad HTTP exception.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    private async ValueTask<bool> HandleBadHttpRequestExceptionAsync(HttpContext httpContext, BadHttpRequestException badHttpException, CancellationToken cancellationToken)
    {
        _logger.LogWarning(badHttpException, "Bad HTTP request exception occurred: {Message}",
            badHttpException.Message);

        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Bad Request",
            Detail = badHttpException.Message,
            Instance = httpContext.Request.Path,
        };

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private static (HttpStatusCode httpStatus, string title) MapGrpcStatusToHttp(StatusCode grpcStatus)
    {
        return grpcStatus switch
        {
            StatusCode.InvalidArgument => (HttpStatusCode.BadRequest, "Invalid Request"),
            StatusCode.NotFound => (HttpStatusCode.NotFound, "Resource Not Found"),
            StatusCode.AlreadyExists => (HttpStatusCode.Conflict, "Resource Already Exists"),
            StatusCode.PermissionDenied => (HttpStatusCode.Forbidden, "Permission Denied"),
            StatusCode.Unauthenticated => (HttpStatusCode.Unauthorized, "Authentication Required"),
            StatusCode.ResourceExhausted => (HttpStatusCode.TooManyRequests, "Too Many Requests"),
            StatusCode.FailedPrecondition => (HttpStatusCode.PreconditionFailed, "Precondition Failed"),
            StatusCode.OutOfRange => (HttpStatusCode.BadRequest, "Request Out of Range"),
            StatusCode.Unimplemented => (HttpStatusCode.NotImplemented, "Not Implemented"),
            StatusCode.Unavailable => (HttpStatusCode.ServiceUnavailable, "Service Unavailable"),
            StatusCode.DeadlineExceeded => (HttpStatusCode.RequestTimeout, "Request Timeout"),
            _ => (HttpStatusCode.InternalServerError, "Internal Server Error")
        };
    }

}
