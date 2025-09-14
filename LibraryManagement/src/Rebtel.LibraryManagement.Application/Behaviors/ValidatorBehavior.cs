using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Rebtel.LibraryManagement.Application.Exceptions;

namespace Rebtel.LibraryManagement.Application.Behaviors;

public class ValidatorBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidatorBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var typeName = request.GetType().Name;

        if (!validators.Any())
        {
            logger.LogDebug("No validators found for {RequestType}", typeName);
            return await next();
        }

        logger.LogDebug("Validating request {RequestType}", typeName);

        var failures = validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .ToList();

        if (failures.Any())
        {
            logger.LogWarning("Validation failed for {RequestType}. Errors: {ValidationErrors}",
                typeName, failures.Select(f => new { Property = f.PropertyName, Error = f.ErrorMessage }));

            throw new ApplicationValidationException(typeName, failures);
        }

        logger.LogDebug("Validation passed for {RequestType}", typeName);
        return await next();
    }
}
