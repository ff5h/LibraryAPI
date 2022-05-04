using Library.Models.DTO.Responses;
using Library.Shared.Interfaces.Services;
using LibraryAPI.Commands.Files;
using MediatR;

namespace LibraryAPI.Handlers.Files
{
    public class UploadFileWithGuidCommandHandler : IRequestHandler<UploadFileCommand<Guid>, UploadFileResponseDTO<Guid>>
    {
        private readonly IDataStorageService<Guid> _storage;

        public UploadFileWithGuidCommandHandler(IDataStorageService<Guid> storage)
        {
            _storage = storage;
        }

        public async Task<UploadFileResponseDTO<Guid>> Handle(UploadFileCommand<Guid> request, CancellationToken cancellationToken)
        {
            var result = await _storage.UploadFile(request.FileStream, request.FileName);
            return new UploadFileResponseDTO<Guid>() { Id = result.Id };
        }
    }
}
