using BookStoreApi.Application.AuthorOperations.Command.DeleteAuthor;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.AuthorOperations.Command.DeleteAuthor;

public class DeleteAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int id)
    {
        // Arrange
        DeleteAuthorCommand command = new DeleteAuthorCommand(null);
        command.AuthorId = id;
        

        // Act
        DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
        var validationResult = validator.Validate(command);

        // Assert
        validationResult.Errors.Count.Should().BeGreaterThan(0);
    }

    [Fact]
    public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
    {
        // Arrange
        DeleteAuthorCommand command = new DeleteAuthorCommand(null);
        command.AuthorId = 1;

        // Act
        DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
        var validationResult = validator.Validate(command);

        // Assert
        validationResult.Errors.Count.Should().Be(0);
    }
    
}