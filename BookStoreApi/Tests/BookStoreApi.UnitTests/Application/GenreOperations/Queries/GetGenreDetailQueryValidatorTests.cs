using BookStoreApi.Application.GenreOperations.Queries.GetGenreDetail;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.GenreOperations.Queries;

public class GetGenreDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
{
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void WhenInvalidGenreIdIsGiven_Validator_ShouldReturnError(int genreId)
    {
        // Arrange
        GetGenreDetailQuery query = new GetGenreDetailQuery(null, null);
        query.GenreId = genreId;

        // Act
        GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
        var validationResult = validator.Validate(query);

        // Assert
        validationResult.Errors.Count.Should().BeGreaterThan(0);
    }

    [Fact]
    public void WhenValidGenreIdIsGiven_Validator_ShouldNotReturnError()
    {
        // Arrange
        GetGenreDetailQuery query = new GetGenreDetailQuery(null, null);
        query.GenreId = 1;

        // Act
        GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
        var validationResult = validator.Validate(query);

        // Assert
        validationResult.Errors.Count.Should().Be(0);
    }
    
}