using Tastease.Core.RecipeAggregate.Requests;
using Tastease.Core.RecipeAggregate.Validators;
using FluentAssertions;
using Xunit;
using FluentValidation;
using Tastease.UnitTests.Collections;

namespace Tastease.UnitTests.Core.Validator
{
    [Collection(nameof(CoreTestCollection))]
    public class BasePaginationRequestTests
    {
        [Theory]
        [InlineData(1, 10)]
        [InlineData(0, 10)]
        [InlineData(1, 99)]
        [InlineData(0, 99)]
        [InlineData(66, 50)]
        [InlineData(7, 2)]
        public void BasePaginationRequest_ShouldPassTheValidation_WhenItHasValidValues(int page, int size) 
        {
            //Arrange
            var paginationRequest = new BasePaginationRequest
            {
                Page = page,
                Size = size,
            };
            var paginationRequestValidator = new BasePaginationRequestValidator();
            //Act
            var validationResult = paginationRequestValidator.Validate(paginationRequest);
            //Assert
            validationResult.Errors.Should().BeEmpty();
            validationResult.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData(-1, 10)]
        [InlineData(-110, 10)]
        [InlineData(-2, 99)]
        [InlineData(-1, 99)]
        [InlineData(int.MinValue, 50)]
        [InlineData(-5, 2)]
        public void BasePaginationRequest_ShouldFailTheValidation_WhenItHasInvalidPageValue(int page, int size)
        {
            //Arrange
            var paginationRequest = new BasePaginationRequest
            {
                Page = page,
                Size = size,
            };
            var paginationRequestValidator = new BasePaginationRequestValidator();
            //Act
            var validationResult = paginationRequestValidator.Validate(paginationRequest);
            //Assert
            validationResult.Errors.Should().HaveCount(1)
                .And.Contain(x => x.PropertyName == nameof(BasePaginationRequest.Page) && x.Severity == Severity.Error);
            validationResult.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData(int.MinValue, int.MaxValue)]
        [InlineData(-1, 100)]
        [InlineData(-2, -1)]
        [InlineData(-110, 0)]
        [InlineData(-69, -1)]
        [InlineData(int.MinValue, 100)]
        public void BasePaginationRequest_ShouldFailTheValidation_WhenItHasInvalidPageAndSizeValue(int page, int size)
        {
            //Arrange
            var paginationRequest = new BasePaginationRequest
            {
                Page = page,
                Size = size,
            };
            var paginationRequestValidator = new BasePaginationRequestValidator();
            //Act
            var validationResult = paginationRequestValidator.Validate(paginationRequest);
            //Assert
            validationResult.Errors.Should().HaveCount(2);
            validationResult.Errors.Should().Contain(x => x.PropertyName == nameof(BasePaginationRequest.Size) && x.Severity == Severity.Error);
            validationResult.Errors.Should().Contain(x => x.PropertyName == nameof(BasePaginationRequest.Page) && x.Severity == Severity.Error);
            validationResult.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData(0, int.MaxValue)]
        [InlineData(1, 100)]
        [InlineData(int.MaxValue, -1)]
        [InlineData(420, 0)]
        [InlineData(69, -1)]
        [InlineData(int.MaxValue, 100)]
        public void BasePaginationRequest_ShouldFailTheValidation_WhenItHasInvalidSizeValue(int page, int size)
        {
            //Arrange
            var paginationRequest = new BasePaginationRequest
            {
                Page = page,
                Size = size,
            };
            var paginationRequestValidator = new BasePaginationRequestValidator();
            //Act
            var validationResult = paginationRequestValidator.Validate(paginationRequest);
            //Assert
            validationResult.Errors.Should().HaveCount(1)
                .And.Satisfy(x => x.PropertyName == nameof(BasePaginationRequest.Size) && x.Severity == Severity.Error);
            validationResult.IsValid.Should().BeFalse();
        }
    }
}
