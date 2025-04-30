using BookStoreApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.AuthorOperations.Queries;

public class GetAuthorDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void WhenAuthorIdValueIsLessThanOrEqualToZero_Validator_ShouldBeReturnErrors(int authorId)
    {
        // Arrange
        GetAuthorDetailQuery query = new GetAuthorDetailQuery(null, null);
        query.AuthorId = authorId;

        // Act
        GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
        var validationResult = validator.Validate(query);

        // Assert
        validationResult.Errors.Count.Should().BeGreaterThan(0);
    }
    
    [Fact]
    public void WhenAuthorIdValueIsGreaterThanZero_Validator_ShouldNotBeReturnError()
    {
        // Arrange
        GetAuthorDetailQuery query = new GetAuthorDetailQuery(null, null);
        query.AuthorId = 1;

        // Act
        GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
        var validationResult = validator.Validate(query);

        // Assert
        validationResult.Errors.Count.Should().Be(0);
    }
}