using MiniStore.Application.Configuration.Commands;

namespace MiniStore.Application.Customers.RegisterCustomer
{
    public class RegisterCustomerCommand : CommandBase<CustomerDto>
    {
        public string Email { get; }

        public string Name { get; }

        public RegisterCustomerCommand(string email, string name)
        {
            Email = email;
            Name = name;
        }
    }
}
