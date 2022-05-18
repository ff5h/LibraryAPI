namespace Library.Shared.Interfaces
{
    public interface IMessage
    {
        public int Id { get; }
        public long UserId { get; }
        public string? Text { get; }
    }
}
