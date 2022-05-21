namespace Library.Shared.Interfaces
{
    public interface IUpdateHandler
    {
        Task HandleUpdateAsync(IUpdate update, CancellationToken cancellationToken);
        Task HandleErrorAsync(Exception exception, CancellationToken cancellationToken);
    }
}
