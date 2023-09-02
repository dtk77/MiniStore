using MiniStore.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Domain.Customers.Events
{
    public class CustomerRegisterEvent : DomainEventBase
    {
        public CustomerId CustomerId { get; }

        public CustomerRegisterEvent(CustomerId customerId)
        {
            CustomerId = customerId;
        }
    }
}
