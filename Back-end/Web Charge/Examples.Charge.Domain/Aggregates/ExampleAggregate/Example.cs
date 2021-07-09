using Abp.Domain.Entities;
using Abp.Events.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Domain.Aggregates.ExampleAggregate
{
    public class Example: Entity, IAggregateRoot
    {
        public string Nome { get; set; }

        public ICollection<IEventData> DomainEvents => throw new NotImplementedException();
    }
}
