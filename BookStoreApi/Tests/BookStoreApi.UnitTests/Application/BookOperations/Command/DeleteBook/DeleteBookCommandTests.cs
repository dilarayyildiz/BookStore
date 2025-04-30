using AutoMapper;
using BookStoreApi.Application.BookOperations.Command.DeleteBook;
using BookStoreApi.DBOperations;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.BookOperations.Command.DeleteBook;

public class DeleteBookCommandTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;

    public DeleteBookCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
    }
    
    [Fact]
    public void WhenAlreadyExistBookIdIsGiven_InvalidOperationException_ShouldBeReturn()
    {
        DeleteBookCommand command = new DeleteBookCommand(_context);
        command.BookId = 100;
        
        FluentActions
            .Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı");
    }
    [Fact]
    public void WhenValidInputsAreGiven_Book_ShouldBeDeleted()
    {
        DeleteBookCommand command = new DeleteBookCommand(_context);
        command.BookId = 1;

        FluentActions.Invoking(() => command.Handle()).Invoke();

        var book = _context.Books.SingleOrDefault(x => x.Id == command.BookId);
        book.Should().BeNull();
    }
    
}