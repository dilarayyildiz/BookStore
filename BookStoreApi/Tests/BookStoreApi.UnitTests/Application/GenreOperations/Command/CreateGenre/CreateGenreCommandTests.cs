using AutoMapper;
using BookStoreApi.Application.GenreOperations.Command.CreateGenre;
using BookStoreApi.DBOperations;
using BookStoreApi.Entities;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.GenreOperations.Command.CreateGenre;

public class CreateGenreCommandTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;

    public CreateGenreCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
    }
    [Fact]
    public void WhenAlreadyExistGenreNameIsGiven_InvalidOperationException_ShouldBeReturn()
    {
        // Arrange (Hazırlık)
        var genre = new Genre() { Name = "Test_WhenAlreadyExistGenreNameIsGiven_InvalidOperationException_ShouldBeReturn" };
        _context.Genres.Add(genre);
        _context.SaveChanges();

        CreateGenreCommand command = new CreateGenreCommand(_context ,null);
        command.Model = new CreateGenreModel() { Name = genre.Name };

        // Act & Assert (Çalıştırma - Doğrulama)
        FluentActions
            .Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Genre already exists.");
    }
    [Fact]
    public void WhenValidInputsAreGiven_Genre_ShouldBeCreated()
    {
        // Arrange
        CreateGenreCommand command = new CreateGenreCommand(_context , null);
        CreateGenreModel model = new CreateGenreModel() { Name = "TestGenre" };
        command.Model = model;

        // Act
        FluentActions.Invoking(() => command.Handle()).Invoke();

        // Assert
        var genre = _context.Genres.SingleOrDefault(g => g.Name == model.Name);

        genre.Should().NotBeNull();
        genre.Name.Should().Be(model.Name);
    }
    
}