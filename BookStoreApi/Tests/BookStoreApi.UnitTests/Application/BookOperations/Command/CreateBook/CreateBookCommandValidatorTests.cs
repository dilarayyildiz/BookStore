using BookStoreApi.Application.BookOperations.Command.CreateBook;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.BookOperations.Command.CreateBook;

public class CreateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
{
    

    [Theory]
    [InlineData("Lord of the Rings", 1, 0)]
    [InlineData("", 100, 0)]
    [InlineData("Lord of the Rings", 1, 1)]
    public void WhenInvalidInputIsGiven_Validator_ShouldBeReturnErrors( string title, int pageCount, int genreId)
    {
        
        // Arrange
        CreateBookCommand command = new CreateBookCommand(null, null);
        command.Model = new CreateBookModel()
        {
            Title = title,
            GenreId = genreId,
            PageCount = pageCount,
            PublishDate = DateTime.Now.Date.AddYears(-1) ,
        };
        // Act
        CreateBookCommandValidator validator = new CreateBookCommandValidator();
        var result = validator.Validate(command);
       
        // Assert
        result.Errors.Count.Should().BeGreaterThan(0);
        
    }
    [Fact]
    public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
    {
        CreateBookCommand command = new CreateBookCommand(null, null);
        command.Model = new CreateBookModel()
        {
            Title = "Lord of the Rings",
            GenreId = 1,
            PageCount = 100,
            PublishDate = DateTime.Now.Date,
        };
        CreateBookCommandValidator validator = new CreateBookCommandValidator();
        var result = validator.Validate(command);

        result.Errors.Count.Should().BeGreaterThan(0);
    }
    [Fact]
    public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
    {
        CreateBookCommand command = new CreateBookCommand(null, null);
        command.Model = new CreateBookModel()
        {
            Title = "Lord of the Rings",
            GenreId = 1,
            PageCount = 100,
            PublishDate = DateTime.Now.Date.AddYears(-2),
        };
        CreateBookCommandValidator validator = new CreateBookCommandValidator();
        var result = validator.Validate(command);

        result.Errors.Count.Should().Be(0);
    }
    
    
}