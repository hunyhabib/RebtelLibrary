using FluentValidation;

namespace Rebtel.LibraryManagement.Application.Queries.Books.GetCommonBorrowedBooks;

internal class GetCommonBorrowedBooksQueryValidation : AbstractValidator<GetCommonBorrowedBooksQuery>
{
    public GetCommonBorrowedBooksQueryValidation()
    {
        RuleFor(x => x.BookId).NotEmpty();
        RuleFor(x => x.Count).GreaterThan(0);
    }
}
