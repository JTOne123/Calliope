using System;

namespace Calliope
{
    public abstract class Entity<TId> : IInternalEventHandler where TId : class, IEquatable<TId>
    {
        private readonly Action<object> _applier;

        protected Entity(Action<object> applier)
        {
            _applier = applier;
        }

        public TId? Id { get; }

        void IInternalEventHandler.Handle(object @event) => When(@event);

        protected abstract void When(object @event);

        protected void Apply(object @event)
        {
            When(@event);
            _applier(@event);
        }
    }
}