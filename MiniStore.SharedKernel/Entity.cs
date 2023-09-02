using MiniStore.SharedKernel.Interfaces;

namespace MiniStore.SharedKernel
{
    public abstract class Entity
    {
        private List<IDomainEvent>? domainEvents;

        public IEnumerable<IDomainEvent> DomainEvents => domainEvents == null ? Enumerable.Empty<IDomainEvent>() : domainEvents.AsReadOnly();
        
        protected void RegisterDomainEvent(IDomainEvent domainEvent)
        {

            domainEvents = domainEvents ?? new List<IDomainEvent>();
            this.domainEvents.Add(domainEvent);
        }
    }
}
