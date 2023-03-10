using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTemplate.Domain
{
    public interface IBaseEntity
    {
        IReadOnlyCollection<BaseDomainEvent> DomainEvents { get; }

        void AddDomainEvent(BaseDomainEvent domainEvent);
        void ClearDomainEvents();
        void RemoveDomainEvent(BaseDomainEvent domainEvent);
    }

    public abstract class BaseEntity<T> : IBaseEntity
    {
        public T id { get; set; }

        private readonly List<BaseDomainEvent> _domainEvents = new();

        [NotMapped]
        public IReadOnlyCollection<BaseDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(BaseDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(BaseDomainEvent domainEvent)
        {
            _domainEvents.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}