using MiniStore.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Domain.Customers.Rules
{
    internal class CustomerEmailMustBeUniqueRule : IBusinessRule
    {
        private readonly ICustomerUniquenessChecker _customerUniquenessChecker;
        
        private readonly string _email;

        public CustomerEmailMustBeUniqueRule(ICustomerUniquenessChecker customerUniquenessChecker, string email)
        {
            _customerUniquenessChecker = customerUniquenessChecker;
            _email = email;
        }

        public string Message => "Customer with this email already exists.";

        public bool IsBroken()
        {
            return !_customerUniquenessChecker.IsUnique(_email);
        }
    }
}
