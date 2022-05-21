namespace Library.Shared.Interfaces.Services
{
    public interface IDataStorageService<T>
    {
        IFileInfo<T> GetFileInfo(T id);
        Task<IFileInfo<T>> UploadFile(Stream stream, string fileName);
    }
}
