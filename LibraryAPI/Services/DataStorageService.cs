using Library.Repository.Interfaces;
using Library.Repository.Models;
using Library.Shared.Interfaces;
using Library.Shared.Interfaces.Services;
using LibraryAPI.Adapters;
using LiteDB;

namespace LibraryAPI.Services
{
    public class DataStorageService : IDataStorageService<Guid>
    {
        private readonly ILiteStorage<Guid> _storage;
        private readonly ILiteDatabase _db;
        private readonly IAppDBContext _ctx;

        public DataStorageService(ILiteDatabase liteDb, IAppDBContext ctx)
        {
            _storage = liteDb.GetStorage<Guid>("Files");
            _db = liteDb;
            _ctx = ctx;
        }
        
        public IFileInfo<Guid> GetFileInfo(Guid id)
        {
            var result = _storage.FindById(id);
            return new LiteFileInfoAdapter<Guid>(result);
        }

        public async Task<IFileInfo<Guid>> UploadFile(Stream stream, string fileName)
        {
            Guid id = Guid.NewGuid();
            var fileStream = _storage.OpenWrite(id, fileName);
            await stream.CopyToAsync(fileStream);
            fileStream.Close();
            _db.Checkpoint();
            var fileInfo = fileStream.FileInfo;
            var attachment = new Attachment()
            {
                Id = fileInfo.Id,
                Name = fileInfo.Filename,
                ContentType = fileInfo.MimeType
            };
            _ctx.Attachments.Add(attachment);
            await _ctx.SaveChangesAsync();
            return new LiteFileInfoAdapter<Guid>(fileInfo);
        }
    }
}
