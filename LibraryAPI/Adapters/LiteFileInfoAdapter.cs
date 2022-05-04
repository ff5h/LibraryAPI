using Library.Shared.Interfaces;
using LiteDB;

namespace LibraryAPI.Adapters
{
    public class LiteFileInfoAdapter<T> : IFileInfo<T>
    {
        private readonly LiteFileInfo<T> _fileInfo;

        public LiteFileInfoAdapter(LiteFileInfo<T> fileInfo)
        {
            _fileInfo = fileInfo;
        }

        public T Id => _fileInfo.Id;

        public string MimeType => _fileInfo.MimeType;
        public string Name => _fileInfo.Filename;

        public Stream OpenRead() => _fileInfo.OpenRead();

        public Stream OpenWrite() => _fileInfo.OpenWrite();
    }
}
