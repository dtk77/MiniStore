using MiniStore.SharedKernel.Interfaces;

namespace MiniStore.SharedKernel
{
    public class DomainEventBase : IDomainEvent
    {
        public DateTime OccurredOn { get; protected set; } = DateTime.UtcNow;

        
    }
}