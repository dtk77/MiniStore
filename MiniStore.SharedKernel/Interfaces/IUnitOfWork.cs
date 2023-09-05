namespace MiniStore.SharedKernel.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
