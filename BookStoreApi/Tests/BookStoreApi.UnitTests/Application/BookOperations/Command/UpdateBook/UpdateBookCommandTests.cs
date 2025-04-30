using BookStoreApi.Application.BookOperations.Command.UpdateBookCommand;
using BookStoreApi.DBOperations;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.BookOperations.Command.UpdateBook;

public class UpdateBookCommandTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    public UpdateBookCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
    }
    public void WhenBookIdIsInvalid_InvalidOperationException_ShouldBeReturn()
    {
        UpdateBookCommand command = new UpdateBookCommand(_context);
        command.BookId = 0;

        FluentActions
            .Invoking(() => command.Handle( command.BookId))
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı");
    }
    [Fact]
    public void WhenValidInputsAreGiven_Book_ShouldBeUpdated()
    {
        UpdateBookCommand command = new UpdateBookCommand(_context);
        UpdateBookModel model = new UpdateBookModel() { Title = "Hobbit", GenreId = 1 };
        command.BookId = 1;
        command.Model = model;
        FluentActions.Invoking(() => command.Handle(command.BookId)).Invoke();
        var book = _context.Books.SingleOrDefault(book => book.Id == command.BookId);
        book.Should().NotBeNull();
        book.Title.Should().Be(model.Title);
        book.GenreId.Should().Be(model.GenreId);
    }
    
}