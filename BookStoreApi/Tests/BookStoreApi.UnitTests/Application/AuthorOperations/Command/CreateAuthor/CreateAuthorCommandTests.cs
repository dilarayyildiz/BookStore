using AutoMapper;
using BookStoreApi.Application.AuthorOperations.Command.CreateAuthor;
using BookStoreApi.DBOperations;
using BookStoreApi.Entities;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.AuthorOperations.Command.CreateAuthor;

public class CreateAuthorCommandTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public CreateAuthorCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }
    
    [Fact]
    public void WhenAlreadyExistAuthorNameIsGiven_InvalidOperationException_ShouldBeReturn()
    {
        // Arrange (Hazırlık)
        var author = new Author()
        {
            Name = "WhenAlreadyExistAuthorNameIsGiven_InvalidOperationException_ShouldBeReturn",
            Surname = "WhenAlreadyExistAuthorNameIsGiven_InvalidOperationException_ShouldBeReturn",
            BirthDate = new DateTime(1990, 01, 10)
        };
        _context.Authors.Add(author);
        _context.SaveChanges();

        CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
        command.Model = new CreateAuthorCommand.CreateAuthorModel()
        {
            Name = author.Name,
            Surname = author.Surname,
            BirthDate = author.BirthDate
        };
        // Act & Assert (calistirma - Dogrulama)
        FluentActions
            .Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar zaten mevcut.");
    }
    [Fact]
    public void WhenValidInputsAreGiven_Author_ShouldBeCreated()
    {
        // Arrange
        CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
        CreateAuthorCommand.CreateAuthorModel model = new CreateAuthorCommand.CreateAuthorModel()
        {
            Name = "WhenValidInputsAreGiven_Author_ShouldBeCreated",
            Surname = "WhenValidInputsAreGiven_Author_ShouldBeCreated",
            BirthDate = new DateTime(1990, 01, 10)
        };
        command.Model = model;

        // Act
        FluentActions.Invoking(() => command.Handle()).Invoke();

        // Assert
        var author = _context.Authors.SingleOrDefault(author => author.Name == model.Name);
        author.Should().NotBeNull();
        author.Name.Should().Be(model.Name);
        author.Surname.Should().Be(model.Surname);
        author.BirthDate.Should().Be(model.BirthDate);
    }
    
}