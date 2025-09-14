using FluentValidation.Results;

namespace Rebtel.LibraryManagement.Application.Exceptions;

/// <summary>
/// Exception thrown when validation fails in the application layer
/// </summary>
public class ApplicationValidationException : Exception
{
    public IReadOnlyCollection<ValidationFailure> ValidationFailures { get; }

    public ApplicationValidationException(string requestType, IEnumerable<ValidationFailure> failures)
        : base($"Validation failed for {requestType}")
    {
        ValidationFailures = failures.ToList().AsReadOnly();
    }

    public ApplicationValidationException(string requestType, IEnumerable<ValidationFailure> failures, Exception innerException)
        : base($"Validation failed for {requestType}", innerException)
    {
        ValidationFailures = failures.ToList().AsReadOnly();
    }
}
