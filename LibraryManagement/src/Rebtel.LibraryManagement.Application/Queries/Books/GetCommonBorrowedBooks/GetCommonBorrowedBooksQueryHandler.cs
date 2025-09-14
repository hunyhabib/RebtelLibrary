using AutoMapper;
using MediatR;
using Rebtel.LibraryManagement.Domain.Repositories;
using Rebtel.LibraryManagement.DTOs;

namespace Rebtel.LibraryManagement.Application.Queries.Books.GetCommonBorrowedBooks;

internal class GetCommonBorrowedBooksQueryHandler(IBookRepository bookRepository, IMapper mapper) : IRequestHandler<GetCommonBorrowedBooksQuery, IEnumerable<BookDTO>>
{
    public async Task<IEnumerable<BookDTO>> Handle(GetCommonBorrowedBooksQuery request, CancellationToken cancellationToken) =>
        mapper.Map<IEnumerable<BookDTO>>(await bookRepository.GetCommonBorrowedBooks(request.BookId, request.Count, cancellationToken));
}
