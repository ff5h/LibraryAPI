using AutoMapper;
using Library.Models.DTO.Models.Files;
using Library.Repository.Interfaces;
using LibraryAPI.Queries.Files;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Handlers.Files
{
    public class GetGuidByFileNameQueryHandler : IRequestHandler<GetGuidByFileNameQuery, FileDTO>
    {
        private readonly IAppDBContext _ctx;
        private readonly IMapper _mapper;

        public GetGuidByFileNameQueryHandler(IAppDBContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<FileDTO> Handle(GetGuidByFileNameQuery request, CancellationToken cancellationToken)
        {
            var fileQuery = _ctx.Attachments.AsQueryable();
            var file = await fileQuery.FirstOrDefaultAsync(f => f.Name == request.Name);
            var result = _mapper.Map<FileDTO>(file);
            return result;
        }
    }
}