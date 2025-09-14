using FluentValidation;

namespace Rebtel.LibraryManagement.Application.Queries.Books.GetMostBorrowedBooks;
internal class GetMostBorrowedBooksQueryValidation : AbstractValidator<GetMostBorrowedBooksQuery>
{
    public GetMostBorrowedBooksQueryValidation()
    {
        RuleFor(x => x.Count).GreaterThan(0);
    }
}
