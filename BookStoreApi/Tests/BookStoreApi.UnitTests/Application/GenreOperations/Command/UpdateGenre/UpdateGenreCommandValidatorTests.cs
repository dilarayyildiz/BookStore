using BookStoreApi.Application.GenreOperations.Command.UpdateGenre;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.GenreOperations.Command.UpdateGenre;

public class UpdateGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
{
    [Theory]
    [InlineData(" ")]
    [InlineData(" ")]
    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name)
    {
        // Arrange
        UpdateGenreCommand command = new UpdateGenreCommand(null, null);
        command.Model = new UpdateGenreModel()
        {
            Name = name
        };

        // Act
        UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
        var validationResult = validator.Validate(command);

        // Assert
        validationResult.Errors.Count.Should().BeGreaterThan(0);
    }
    [Fact]
    public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
    {
        // Arrange
        UpdateGenreCommand command = new UpdateGenreCommand(null, null);
        command.Model = new UpdateGenreModel()
        {
            Name = "Test"
        };

        // Act
        UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
        var validationResult = validator.Validate(command);

        // Assert
        validationResult.Errors.Count.Should().Be(0);
    }
   
    
}