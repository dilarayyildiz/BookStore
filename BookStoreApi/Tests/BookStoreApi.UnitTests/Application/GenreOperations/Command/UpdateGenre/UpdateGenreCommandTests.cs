using BookStoreApi.Application.GenreOperations.Command.UpdateGenre;
using BookStoreApi.DBOperations;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.GenreOperations.Command.UpdateGenre;

public class UpdateGenreCommandTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    public UpdateGenreCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
    }
    [Fact]
    public void WhenNonExistingGenreIdIsGiven_InvalidOperationException_ShouldBeReturn()
    {
        //Arrange
        UpdateGenreCommand command = new UpdateGenreCommand(_context , null);
        command.GenreId = 0;
        //Act & Assert
        FluentActions
            .Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Genre not found");
    }
    [Fact]
    public void WhenAlreadyExistGenreNameIsGiven_InvalidOperationException_ShouldBeReturn()
    {
        //Arrange
        UpdateGenreCommand command = new UpdateGenreCommand(_context , null);
        command.GenreId = 1;
        command.Model = new UpdateGenreModel() { Name = "Personal Growth" };
        //Act & Assert
        FluentActions
            .Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("A genre with the same name already exists.");
    }
    
}