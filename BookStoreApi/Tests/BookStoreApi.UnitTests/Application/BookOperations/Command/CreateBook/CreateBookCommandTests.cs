using AutoMapper;
using BookStoreApi.Application.BookOperations.Command.CreateBook;
using BookStoreApi.DBOperations;
using BookStoreApi.Entities;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.BookOperations.Command.CreateBook;

public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public CreateBookCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }
    [Fact]
    public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
    {
        //Arrange(hazırlama)
        var book = new Book() { Title = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn", 
                                PageCount = 100, PublishDate = new DateTime(1990, 01, 01), GenreId = 1 };
        _context.Books.Add(book);
        _context.SaveChanges();

        CreateBookCommand command = new CreateBookCommand(_context, _mapper);
        command.Model = new CreateBookModel() { Title = book.Title };

        //Act(çalıştırma) & Assert(doğrulama)
        FluentActions
            .Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");
    }
    [Fact]
    public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
    {
        //Arrange
        CreateBookCommand command = new CreateBookCommand(_context, _mapper);
        CreateBookModel model = new CreateBookModel()
        {
            Title = "Hobbit",
            PageCount = 100,
            PublishDate = DateTime.Now.Date.AddYears(-10),
            GenreId = 1
        };
        command.Model = model;
        //Act
        FluentActions.Invoking(() => command.Handle()).Invoke();
        //Assert
        var book = _context.Books.SingleOrDefault(book => book.Title == model.Title);
        book.Should().NotBeNull();
        book.PageCount.Should().Be(model.PageCount);
        book.PublishDate.Should().Be(model.PublishDate);
        book.GenreId.Should().Be(model.GenreId);
        
    }
     
    
}