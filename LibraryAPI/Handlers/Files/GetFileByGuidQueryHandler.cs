using Library.Shared.Interfaces.Services;
using LibraryAPI.Queries.Files;
using MediatR;

namespace LibraryAPI.Handlers.Files
{
    public class GetFileByGuidQueryHandler : IRequestHandler<GetFileQuery<Guid>, (Stream FileStream, string ContentType)>
    {
        private readonly IDataStorageService<Guid> _storage;

        public GetFileByGuidQueryHandler(IDataStorageService<Guid> storage)
        {
            _storage = storage;
        }

        public Task<(Stream FileStream, string ContentType)> Handle(GetFileQuery<Guid> request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var fileInfo = _storage.GetFileInfo(request.Id);
                return (FileSream: fileInfo.OpenRead(),
                        ContentType: fileInfo.MimeType);
            });
        }
    }
}
