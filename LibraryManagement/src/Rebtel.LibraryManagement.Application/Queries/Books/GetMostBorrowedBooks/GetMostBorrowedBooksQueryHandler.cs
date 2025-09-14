using AutoMapper;
using MediatR;
using Rebtel.LibraryManagement.Domain.Repositories;
using Rebtel.LibraryManagement.DTOs;

namespace Rebtel.LibraryManagement.Application.Queries.Books.GetMostBorrowedBooks;

internal class GetMostBorrowedBooksQueryHandler(IBookRepository bookRepository, IMapper mapper) : IRequestHandler<GetMostBorrowedBooksQuery, IEnumerable<BookDTO>>
{
    public async Task<IEnumerable<BookDTO>> Handle(GetMostBorrowedBooksQuery request, CancellationToken cancellationToken) =>
       mapper.Map<IEnumerable<BookDTO>>(await bookRepository.GetMostBorrowedBooks(request.Count,cancellationToken));
}
