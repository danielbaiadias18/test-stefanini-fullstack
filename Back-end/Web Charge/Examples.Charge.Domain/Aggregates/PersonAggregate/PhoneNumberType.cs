using Abp.Domain.Entities;
using Abp.Events.Bus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PhoneNumberType
    {
        public int PhoneNumberTypeID { get; set; }

        public string Name { get; set; }

        public ICollection<IEventData> DomainEvents => throw new NotImplementedException();
    }
}
