using MiniStore.SharedKernel;
using MiniStore.SharedKernel.Interfaces;
using NSubstitute;

namespace MiniStore.UnitTests.SharedKernel
{
    public class BusinessRuleValidationExceptionTests
    {
        [Fact]
        public void Constructing_WithBrokenRule_SetsBrokenRuleAndDetails()
        {
            //Arrange
            var brokenRule = Substitute.For<IBusinessRule>();
            brokenRule.Message.Returns("Business rule message");

            //Act
            var exception = new BusinessRuleValidationException(brokenRule);

            //Assert
            Assert.Equal(brokenRule, exception.BrokenRule);
            Assert.Equal(brokenRule.Message, exception.Details);
        }

        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            //Arrange
            var brokenRule = Substitute.For<IBusinessRule>();
            brokenRule.Message.Returns("Business rule message");
            var exception = new BusinessRuleValidationException(brokenRule);

            //Act
            var result = exception.ToString();

            //Assert
            var expected = $"{brokenRule.GetType().FullName}: {brokenRule.Message}";
            Assert.Equal(expected, result);
        }

    }
}
