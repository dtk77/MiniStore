using MiniStore.Domain.Customers.Events;
using MiniStore.Domain.Customers.Orders;
using MiniStore.Domain.Customers.Rules;
using MiniStore.SharedKernel;
using MiniStore.SharedKernel.Interfaces;

namespace MiniStore.Domain.Customers
{
    public class Customer : Entity, IAggregateRoot
    {
        public CustomerId Id { get; private set; }

        private string _name;

        private string _email;

        private readonly List<Order> _orders = new List<Order>();

        private bool _welcomeEmailWasSent;

        private Customer(string email, string name)
        {
            Id = new CustomerId(Guid.NewGuid());
            _email = email;
            _name = name;
            _welcomeEmailWasSent = false;
            _orders = new List<Order>();

            base.RegisterDomainEvent(new CustomerRegisterEvent(Id));
        }

        public static Customer CreateRegistered(string name, string email, ICustomerUniquenessChecker customerUniquenessChecker)
        {
            CheckRule(new CustomerEmailMustBeUniqueRule(customerUniquenessChecker, email));

            return new Customer(email, name);
        }


    }
}
