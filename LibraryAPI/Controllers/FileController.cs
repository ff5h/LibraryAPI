using Library.Models.DTO.Models.Files;
using LibraryAPI.Commands.Files;
using LibraryAPI.Queries.Files;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly ISender _sender;
        public FileController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("DownloadFile")]
        public async Task<IActionResult> DownloadFile(Guid id)
        {
            var request = new GetFileQuery<Guid> { Id = id };
            var result = await _sender.Send(request);
            return new FileStreamResult(result.FileStream, result.ContentType);
        }

        [HttpGet("GetFileGuid")]
        public async Task<FileDTO> GetFileGuid(string name)
        {
            var request = new GetGuidByFileNameQuery { Name = name };
            var result = await _sender.Send(request);
            return result;
        }

        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var request = new UploadFileCommand<Guid>
            {
                FileName = file.FileName,
                FileStream = file.OpenReadStream()
            };

            var result = await _sender.Send(request);

            return Ok(result);
        }
    }
}
