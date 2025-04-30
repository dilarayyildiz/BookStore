using BookStoreApi.Application.BookOperations.Command.DeleteBook;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.BookOperations.Command.DeleteBook;

public class DeleteBookCommandValidatorTests :IClassFixture<CommonTestFixture>
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void WhenLowerThanAndEqualToZeroIdIsGiven_Validator_ShouldBeReturnErrors(int bookId)
    {
        //arrange
        DeleteBookCommand command = new DeleteBookCommand(null);
        command.BookId = bookId;
        //act
        DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
        var result = validator.Validate(command);
        //assert
        result.Errors.Count.Should().BeGreaterThan(0);
    }
    [Fact]
    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
    {
        //arrange
        DeleteBookCommand command = new DeleteBookCommand(null);
        command.BookId = 0;
        //act
        DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
        var result = validator.Validate(command);
        //assert
        result.Errors.Count.Should().BeGreaterThan(0);
    }
    [Fact]
    public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors()
    {
        //arrange
        DeleteBookCommand command = new DeleteBookCommand(null);
        command.BookId = 1;
        //act
        DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
        var result = validator.Validate(command);
        //assert
        result.Errors.Count.Should().Be(0);
    }
    
}