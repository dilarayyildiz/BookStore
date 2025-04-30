using BookStoreApi.Application.BookOperations.Queries.GetBookDetail;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.BookOperations.Queries;

public class GetBookDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void WhenInvalidBookIdIsGiven_Validator_ShouldBeReturnErrors(int bookId)
    {
        // Arrange
        GetBookDetailQuery query = new GetBookDetailQuery(null, null);
        query.BookId = bookId;

        // Act
        GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
        var validationResult = validator.Validate(query);

        // Assert
        validationResult.Errors.Count.Should().BeGreaterThan(0);
    }

    [Fact]
    public void WhenValidBookIdIsGiven_Validator_ShouldNotBeReturnError()
    {
        // Arrange
        GetBookDetailQuery query = new GetBookDetailQuery(null, null);
        query.BookId = 1;

        // Act
        GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
        var validationResult = validator.Validate(query);

        // Assert
        validationResult.Errors.Count.Should().Be(0);
    }
    
}