using MediatR;

namespace MiniStore.SharedKernel.Interfaces
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}
