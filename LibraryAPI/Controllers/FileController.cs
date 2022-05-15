using LibraryAPI.Commands.Files;
using LibraryAPI.Queries.Files;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly ISender _sender;
        public FileController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> DownloadFile(Guid id)
        {
            var request = new GetFileQuery<Guid> { Id = id };
            var result = await _sender.Send(request);
            return new FileStreamResult(result.FileStream, result.ContentType);
        }

        [HttpPost]
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
