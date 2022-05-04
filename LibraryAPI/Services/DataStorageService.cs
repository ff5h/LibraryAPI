using Library.Shared.Interfaces;
using Library.Shared.Interfaces.Services;
using LibraryAPI.Adapters;
using LiteDB;

namespace LibraryAPI.Services
{
    public class DataStorageService<T> : IDataStorageService<T>
    {
        private readonly ILiteStorage<T> _storage;
        private readonly ILiteDatabase _db;

        public DataStorageService(ILiteDatabase liteDb)
        {
            _storage = liteDb.GetStorage<T>("Files");
            _db = liteDb;
        }
        
        public IFileInfo<T> GetFileInfo(T id)
        {
            var result = _storage.FindById(id);
            return new LiteFileInfoAdapter<T>(result);
        }

        public async Task<IFileInfo<T>> UploadFile(Stream stream, string fileName)
        {
            T id;
            if (typeof(T).IsAssignableFrom(typeof(Guid)))
            {
                id = (T)(object)Guid.NewGuid();
                var fileStream = _storage.OpenWrite(id, fileName);
                await stream.CopyToAsync(fileStream);
                fileStream.Close();
                _db.Checkpoint();
                return new LiteFileInfoAdapter<T>(fileStream.FileInfo);
            }
            throw new NotSupportedException("Support only GUID file storage");
        }
    }
}
