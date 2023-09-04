using MiniStore.SharedKernel;
using MiniStore.SharedKernel.Interfaces;
using NSubstitute;

namespace MiniStore.UnitTests.SharedKernel
{
    public class TestEntity : Entity
    {
        public void TestRegisterDomainEvent(IDomainEvent domainEvent)
        {
            RegisterDomainEvent(domainEvent);
        }

        public void TestCheckRule(IBusinessRule rule)
        {
            CheckRule(rule);
        }
      
        public void TestClearDomainEvent()
        {
            ClearDomainEvents();
        }
    }

    public class EntityTests
    {
        [Fact]
        public void TestRegisterDomainEvent_AddsEventToDomainEvents()
        {
            //Arrange
            var testEntity = new TestEntity();
            var domainEvent = Substitute.For<IDomainEvent>();

            //Act
            testEntity.TestRegisterDomainEvent(domainEvent);

            //Assert
            var domainEvents = testEntity.DomainEvents.ToList();
            Assert.Single(domainEvents);
            Assert.Contains(domainEvent, domainEvents);
        }

        [Fact]
        public void TestCheckRule_WhenRuleIsBrocken()
        {
            //Arrange 
            var testEntity = new TestEntity();
            var brokenRule = Substitute.For<IBusinessRule>();
            brokenRule.IsBroken().Returns(true);

            //Act
           var exception = Record.Exception(()=> testEntity.TestCheckRule(brokenRule));

            //Assert
            Assert.NotNull(exception);
            Assert.IsType<BusinessRuleValidationException>(exception);
            Assert.Equal(brokenRule, ((BusinessRuleValidationException)exception).BrokenRule);
        }

        [Fact]
        public void TestCheckRule_WhenRuleIsNotBrocken()
        {
            //Arrange
            var testEntity = new TestEntity();
            var notBrokenRule = Substitute.For<IBusinessRule>();
            notBrokenRule.IsBroken().Returns(false);

            //Act
            var exception = Record.Exception(() => testEntity.TestCheckRule(notBrokenRule));

            //Assert
            Assert.Null(exception);
        }

        [Fact]
        public void TestClearDomainEvent_DomainEventsWillBeEmpty()
        {
            //Arrange
            var testEntity = new TestEntity();
            var eventDomains = Substitute.For<IDomainEvent>();
            testEntity.TestRegisterDomainEvent(eventDomains);

            //Act
            testEntity.TestClearDomainEvent();

            //Assert
            Assert.Empty(testEntity.DomainEvents);
        }
    }
}
