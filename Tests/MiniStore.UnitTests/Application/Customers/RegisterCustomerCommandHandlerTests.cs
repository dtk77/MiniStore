using MiniStore.Application.Customers.RegisterCustomer;
using MiniStore.Domain.Customers;
using MiniStore.SharedKernel.Interfaces;
using NSubstitute;
using FluentAssertions;

namespace MiniStore.UnitTests.Application.Customers
{
    public class RegisterCustomerCommandHandlerTests
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerUniquenessChecker _customerUniquenessChecker;
        private readonly IUnitOfWork _unitOfWork;
        private readonly RegisterCustomerCommandHandler _handler;

        public RegisterCustomerCommandHandlerTests()
        {
            _customerRepository = Substitute.For<ICustomerRepository>();
            _customerUniquenessChecker = Substitute.For<ICustomerUniquenessChecker>();
            _unitOfWork = Substitute.For<IUnitOfWork>();

            _handler = new RegisterCustomerCommandHandler(_customerRepository, _customerUniquenessChecker, _unitOfWork);
        }

        [Fact]
        public async Task Handle_ShouldAddCustomerToRepository()
        {
            //Arrange
            var command = new RegisterCustomerCommand("any@mail.com", "anyName");
            _customerUniquenessChecker.IsUnique(command.Email).Returns(true);

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert
            await _customerRepository.Received(1).AddAsync(Arg.Any<Customer>());
            await _unitOfWork.Received(1).CommitAsync(CancellationToken.None);
            result.Should().NotBeNull();
            result.Id.Should().NotBeEmpty();
        }
    }
}
