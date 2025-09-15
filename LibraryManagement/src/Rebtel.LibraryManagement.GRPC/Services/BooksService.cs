using Grpc.Core;
using MediatR;
using Rebtel.LibraryManagement.Application.Exceptions;
using Rebtel.LibraryManagement.Contracts;

namespace Rebtel.LibraryManagement.GRPC.Services
{
    public class BooksService(IMediator mediator, ILogger<BooksService> logger) : Contracts.BooksService.BooksServiceBase
    {
        /// <summary>
        /// Gets the most borrowed books within a date range
        /// </summary>
        /// <param name="request">The request received from the client.</param>
        /// <param name="context">The context of the server-side call handler being invoked.</param>
        /// <returns>A response containing the most borrowed books</returns>
        public override async Task<GetMostBorrowedBooksResponse> GetMostBorrowedBooks(GetMostBorrowedBooksRequest request, ServerCallContext context)
        {
            try
            {
                logger.LogInformation("GetMostBorrowedBooks called with count: {Count}", request.Count);

                if (request == null)
                    throw new RpcException(new Status(StatusCode.InvalidArgument, "Request cannot be null"));


                var result = await mediator.Send(new Application.Queries.Books.GetMostBorrowedBooks.GetMostBorrowedBooksQuery(request.Count), context.CancellationToken);

                var response = new GetMostBorrowedBooksResponse();
                foreach (var bookDto in result)
                {
                    response.Books.Add(MapBookDtoToProtoDto(bookDto));
                }

                logger.LogInformation("GetMostBorrowedBooks completed successfully, returned {BookCount} books", result.Count());
                return response;
            }
            catch (ApplicationValidationException ex)
            {
                logger.LogWarning("Validation failed for GetMostBorrowedBooks: {ValidationErrors}",
                    ex.ValidationFailures.Select(f => $"{f.PropertyName}: {f.ErrorMessage}"));

                throw new RpcException(new Status(StatusCode.InvalidArgument,
                    $"Validation failed: {string.Join(", ", ex.ValidationFailures.Select(f => f.ErrorMessage))}"));
            }
            catch (RpcException)
            {
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error in GetMostBorrowedBooks");
                throw new RpcException(new Status(StatusCode.Internal, "An unexpected error occurred"));
            }
        }

        /// <summary>
        /// Gets books commonly borrowed with a specific book
        /// </summary>
        /// <param name="request">The request received from the client.</param>
        /// <param name="context">The context of the server-side call handler being invoked.</param>
        /// <returns>A response containing books commonly borrowed with the specified book</returns>
        public override async Task<GetCommonBorrowedBooksResponse> GetCommonBorrowedBooks(GetCommonBorrowedBooksRequest request, ServerCallContext context)
        {
            try
            {
                logger.LogInformation("GetCommonBorrowedBooks called with bookId: {BookId}, count: {Count}", request.BookId, request.Count);

                if (request == null)
                    throw new RpcException(new Status(StatusCode.InvalidArgument, "Request cannot be null"));

                var bookIdGuid = Guid.TryParse(request.BookId, out var bookId);
                var result = await mediator.Send(new Application.Queries.Books.GetCommonBorrowedBooks.GetCommonBorrowedBooksQuery(bookId, request.Count), context.CancellationToken);

                var response = new GetCommonBorrowedBooksResponse();
                foreach (var bookDto in result)
                {
                    response.Books.Add(MapBookDtoToProtoDto(bookDto));
                }

                logger.LogInformation("GetCommonBorrowedBooks completed successfully, returned {BookCount} books", result.Count());
                return response;
            }
            catch (ApplicationValidationException ex)
            {
                logger.LogWarning("Validation failed for GetCommonBorrowedBooks: {ValidationErrors}",
                    ex.ValidationFailures.Select(f => $"{f.PropertyName}: {f.ErrorMessage}"));

                throw new RpcException(new Status(StatusCode.InvalidArgument,
                    $"Validation failed: {string.Join(", ", ex.ValidationFailures.Select(f => f.ErrorMessage))}"));
            }
            catch (RpcException)
            {
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error in GetCommonBorrowedBooks");
                throw new RpcException(new Status(StatusCode.Internal, "An unexpected error occurred"));
            }
        }

        private static BookDto MapBookDtoToProtoDto(DTOs.BookDTO bookDto) =>
            new BookDto
            {
                Id = bookDto.Id.ToString(),
                Title = bookDto.Title ?? string.Empty,
                Author = bookDto.Author ?? string.Empty,
                Isbn = bookDto.ISBN ?? string.Empty,
                PageCount = bookDto.PageCount,
                PublishedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(bookDto.PublishedDate.ToUniversalTime()),
                CopiesAvailable = bookDto.CopiesAvailable
            };
    }
}
