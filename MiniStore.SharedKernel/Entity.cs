using MiniStore.SharedKernel.Interfaces;

namespace MiniStore.SharedKernel
{
    public abstract class Entity
    {
        private List<IDomainEvent>? _domainEvents;

        public IEnumerable<IDomainEvent> DomainEvents =>
            _domainEvents == null ? Enumerable.Empty<IDomainEvent>() : _domainEvents.AsReadOnly();
        
        protected void RegisterDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents() => _domainEvents?.Clear();

        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }
    }
}
