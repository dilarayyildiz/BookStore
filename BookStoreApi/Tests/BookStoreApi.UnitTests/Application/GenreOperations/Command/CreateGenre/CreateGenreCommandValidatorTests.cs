using BookStoreApi.Application.GenreOperations.Command.CreateGenre;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.GenreOperations.Command.CreateGenre;

public class CreateGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
{
    [Theory]
    [InlineData(" ")]
    [InlineData(" ")]
    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name)
    {
        // Arrange
        CreateGenreCommand command = new CreateGenreCommand(null, null);
        command.Model = new CreateGenreModel()
        {
            Name = name
        };

        // Act
        CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
        var validationResult = validator.Validate(command);

        // Assert
        validationResult.Errors.Count.Should().BeGreaterThan(0);
    }
    
}