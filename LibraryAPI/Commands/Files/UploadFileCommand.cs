using Library.Models.DTO.Responses;
using MediatR;

namespace LibraryAPI.Commands.Files
{
    public class UploadFileCommand<T> : IRequest<UploadFileResponseDTO<T>>
    {
        public string FileName { get; init; }
        public Stream FileStream { get; init; }
    }
}
