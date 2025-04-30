using BookStoreApi.Application.BookOperations.Command.UpdateBookCommand;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.BookOperations.Command.UpdateBook;

public class UpdateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void WhenLowerThanAndEqualToZeroIdIsGiven_Validator_ShouldBeReturnErrors(int bookId)
    {
        //arrange
        UpdateBookCommand command = new UpdateBookCommand(null);
        command.BookId = bookId;
        //act
        UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
        var result = validator.Validate(command);
        //assert
        result.Errors.Count.Should().BeGreaterThan(0);
    }
    [Fact]
    public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
    {
        //arrange
        UpdateBookCommand command = new UpdateBookCommand(null);
        command.BookId = 1;
        //act
        UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
        var result = validator.Validate(command);
        //assert
        result.Errors.Count.Should().Be(0);
    }
    [Fact]
    public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
    {
        //arrange
        UpdateBookCommand command = new UpdateBookCommand(null);
        command.BookId = 1;
        command.Model = new UpdateBookModel()
        {
            Title = "Lord Of The Rings",
            GenreId = 1,
        };
        //act
        UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
        var result = validator.Validate(command);
        //assert
        result.Errors.Count.Should().BeGreaterThan(0);
    }
    
}