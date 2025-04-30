using BookStoreApi.Application.AuthorOperations.Command.UpdateAuthor;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.AuthorOperations.Command.UpdateAuthor;

public class UpdateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
{
    private UpdateAuthorCommandValidator _validator;

    public UpdateAuthorCommandValidatorTests()
    {
        _validator = new UpdateAuthorCommandValidator();
    }

    [Theory]
    [InlineData(0, "")]
    [InlineData(0, " ")]
    [InlineData(0, "a")]
    [InlineData(1, "")]
    [InlineData(1, " ")]
    [InlineData(1, "a")]
    public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(int authorId, string name)
    {
        // Arrange
        UpdateAuthorCommand command = new UpdateAuthorCommand(null, null);
        command.AuthorId = authorId;
        command.Model = new UpdateAuthorModel()
        {
            Name = name
        };
        
        // Act
        UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
        var validationResult = validator.Validate(command); 
        // Assert
        validationResult.Errors.Count.Should().BeGreaterThan(0);
        validationResult.Errors.Should().Contain(x => x.PropertyName == "AuthorId");
        validationResult.Errors.Should().Contain(x => x.PropertyName == "Model");
    }   

    [Fact]
    public void WhenValidInputsAreGiven_Validator_ShouldNotReturnErrors()
    {
        // Arrange
        UpdateAuthorCommand command = new UpdateAuthorCommand(null, null);
        command.AuthorId = 1;
        command.Model = new UpdateAuthorModel()
        {
            Name = "a"
        };
        
        // Act
        UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
        var validationResult = validator.Validate(command); 
        // Assert
        validationResult.Errors.Count.Should().Be(0);
    }
            
    
}