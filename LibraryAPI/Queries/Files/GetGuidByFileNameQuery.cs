using Library.Models.DTO.Models.Files;
using MediatR;

namespace LibraryAPI.Queries.Files
{
    public class GetGuidByFileNameQuery : IRequest<FileDTO>
    {
        public string Name { get; init; }
    }
}
