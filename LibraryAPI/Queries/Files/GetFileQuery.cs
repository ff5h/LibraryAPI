using MediatR;

namespace LibraryAPI.Queries.Files
{
    public class GetFileQuery<T> : IRequest<(Stream FileStream, string ContentType)>
    {
        public T Id { get; init; }
    }
}
