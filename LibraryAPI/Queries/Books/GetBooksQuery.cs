using Library.Models.DTO.Models.Book;
using MediatR;

namespace LibraryAPI.Queries.Books
{
    public class GetBooksQuery : IRequest<IEnumerable<BookDTO>> //Это то, что я запрашиваю
    {

    }
}
