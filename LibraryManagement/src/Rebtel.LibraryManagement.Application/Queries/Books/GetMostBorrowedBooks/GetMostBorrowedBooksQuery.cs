using MediatR;
using Rebtel.LibraryManagement.DTOs;

namespace Rebtel.LibraryManagement.Application.Queries.Books.GetMostBorrowedBooks;

public record GetMostBorrowedBooksQuery(int Count) : IRequest<IEnumerable<BookDTO>>;
