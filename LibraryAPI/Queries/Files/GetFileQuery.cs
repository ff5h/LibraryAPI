using MediatR;

namespace LibraryAPI.Queries.Files
{
    public class GetFileQuery<T> : IRequest<Tuple<Stream, string>>
    {
        public T Id { get; init; }
    }
}
