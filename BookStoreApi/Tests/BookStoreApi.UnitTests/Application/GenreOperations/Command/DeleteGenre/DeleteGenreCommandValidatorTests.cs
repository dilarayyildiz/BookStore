using BookStoreApi.Application.GenreOperations.Command.DeleteGenre;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.GenreOperations.Command.DeleteGenre;

public class DeleteGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int genreId)
    {
        // Arrange
        DeleteGenreCommand command = new DeleteGenreCommand(null);
        command.GenreId = genreId;

        // Act
        DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
        var validationResult = validator.Validate(command);

        // Assert
        validationResult.Errors.Count.Should().BeGreaterThan(0);
    }
    [Fact]
    public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors()
    {
        // Arrange
        DeleteGenreCommand command = new DeleteGenreCommand(null);
        command.GenreId = 1;

        // Act
        DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
        var validationResult = validator.Validate(command);

        // Assert
        validationResult.Errors.Count.Should().Be(0);
    }
    
}