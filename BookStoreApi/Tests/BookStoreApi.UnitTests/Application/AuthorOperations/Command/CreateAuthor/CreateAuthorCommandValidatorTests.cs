using BookStoreApi.Application.AuthorOperations.Command.CreateAuthor;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.AuthorOperations.Command.CreateBook;

public class CreateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
{
    [Theory]
    [InlineData("a", "a")]
    [InlineData("a", "")]
    [InlineData("", "a")]
    [InlineData("", "")]
    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname)
    {
        // Arrange
        CreateAuthorCommand command = new CreateAuthorCommand(null, null);
        command.Model = new CreateAuthorCommand.CreateAuthorModel()
        {
            Name = name,
            Surname = surname
        };

        // Act
        CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
        var validationResult = validator.Validate(command);

        // Assert
        validationResult.Errors.Count.Should().BeGreaterThan(0);
    }
    [Fact]
    public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
    {
        // Arrange
        CreateAuthorCommand command = new CreateAuthorCommand(null, null);
        command.Model = new CreateAuthorCommand.CreateAuthorModel()
        {
            Name = "a",
            Surname = "a"
        };

        // Act
        CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
        var validationResult = validator.Validate(command);

        // Assert
        validationResult.Errors.Count.Should().Be(0);
    }
    
    
}