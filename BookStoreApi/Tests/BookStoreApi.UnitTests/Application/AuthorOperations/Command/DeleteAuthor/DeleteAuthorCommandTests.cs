using BookStoreApi.Application.AuthorOperations.Command.DeleteAuthor;
using BookStoreApi.DBOperations;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.AuthorOperations.Command.DeleteBook;

public class DeleteAuthorCommandTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;

    public DeleteAuthorCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
    }
    [Fact]
    public void WhenAuthorNotFound_InvalidOperationException_ShouldBeReturn()
    {
        //Arrange
        var command = new DeleteAuthorCommand(_context);
        command.AuthorId = 0;

        //Act - Assert
        FluentActions
            .Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar Bulunamadı");
    }
    [Fact]
    public void WhenValidInputsAreGiven_Author_ShouldBeDeleted()
    {
        //Arrange
        var command = new DeleteAuthorCommand(_context);
        command.AuthorId = 1;

        //Act
        FluentActions.Invoking(() => command.Handle()).Invoke();

        //Assert
        var author = _context.Authors.SingleOrDefault(x => x.Id == command.AuthorId);
        author.Should().BeNull();
    }
    
    
}