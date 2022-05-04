using Library.Shared.Interfaces.Services;
using LibraryAPI.Queries.Files;
using MediatR;

namespace LibraryAPI.Handlers.Files
{
    public class GetFileByGuidQueryHandler : IRequestHandler<GetFileQuery<Guid>, Tuple<Stream, string>>
    {
        private readonly IDataStorageService<Guid> _storage;

        public GetFileByGuidQueryHandler(IDataStorageService<Guid> storage)
        {
            _storage = storage;
        }

        public Task<Tuple<Stream, string>> Handle(GetFileQuery<Guid> request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var fileInfo = _storage.GetFileInfo(request.Id);
                return new Tuple<Stream, string>(fileInfo.OpenRead(), fileInfo.MimeType);
            });
        }
    }
}
