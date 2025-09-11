using Grpc.Core;
using MediatR;

namespace Rebtel.LibraryManagement.GRPC.Services
{
    public class BooksService(ILogger<BooksService> logger, IMediator mediator) : GRPC.BooksService.BooksServiceBase
    {

        public override async Task<GetMostLoanedBooksResponse> GetMostLoanedBooks(GetMostLoanedBooksRequest request, ServerCallContext context)
        {
            var result = await mediator.Send(new Application.Queries.Books.GetMostLoanedBooksQuery());
            return new GetMostLoanedBooksResponse()
            {
                Books =
                {
                    result.Select(b => new BookDto
                    {
                        Id = b.Id.ToString(),
                        Title = b.Title,
                        Author = b.Author,
                        ISBN = b.ISBN
                    })
                }
            };
        }
    }
}
