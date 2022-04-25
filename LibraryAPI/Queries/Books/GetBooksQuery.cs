using Library.Models.DTO.Models.Books;
using MediatR;

namespace LibraryAPI.Queries.Books
{
    public class GetBooksQuery : IRequest<IEnumerable<BookDTO>> //Это то, что я запрашиваю
    {

    }
}
