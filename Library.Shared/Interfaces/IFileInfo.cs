namespace Library.Shared.Interfaces
{
    public interface IFileInfo<T>
    {
        Stream OpenRead();
        Stream OpenWrite();
        string MimeType { get; }
        string Name { get; }
        T Id { get; }
    }
}
