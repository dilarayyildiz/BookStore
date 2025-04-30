using BookStoreApi.Application.GenreOperations.Command.DeleteGenre;
using BookStoreApi.DBOperations;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.GenreOperations.Command.DeleteGenre;

public class DeleteGenreCommandTests : IClassFixture<CommonTestFixture>
{
        private readonly BookStoreDbContext _context;

    public DeleteGenreCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
    }
    [Fact]
    public void WhenGivenGenreIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
    {
        //arrange (Hazırlık)

        DeleteGenreCommand command = new DeleteGenreCommand(_context);
        command.GenreId=0;

        //act & assert (Çalıştırma - Doğrulama)
        FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Genre not found");

    }

    [Fact]
    public void WhenGivenGenreIdIsinDB_InvalidOperationException_ShouldBeReturn()
    {
        //arrange (Hazırlık)

        DeleteGenreCommand command = new DeleteGenreCommand(_context);
        command.GenreId=1;

        //act & assert (Çalıştırma - Doğrulama)
        FluentActions.Invoking(() => command.Handle()).Invoke();

        var genre=_context.Genres.SingleOrDefault(genre=>genre.Id==command.GenreId);
        genre.Should().BeNull();
    }
    
}