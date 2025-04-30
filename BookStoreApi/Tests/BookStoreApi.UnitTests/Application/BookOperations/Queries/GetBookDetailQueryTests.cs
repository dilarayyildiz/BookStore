using AutoMapper;
using BookStoreApi.Application.BookOperations.Queries.GetBookDetail;
using BookStoreApi.DBOperations;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.BookOperations.Queries;

public class GetBookDetailQueryTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public GetBookDetailQueryTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }
    [Fact]
    public void WhenBookIdNotExist_InvalidOperationException_ShouldBeReturn()
    {
        // Arrange
        var bookId = 0;
        var query = new GetBookDetailQuery(_context, _mapper);
        query.BookId = bookId;

        // Act & Assert
        FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı");
    }
    [Fact]
    public void WhenBookIdExist_InvalidOperationException_ShouldNotBeReturn()
    {
        // Arrange
        var bookId = 1;
        var query = new GetBookDetailQuery(_context, _mapper);
        query.BookId = bookId;

        // Act & Assert
        FluentActions.Invoking(() => query.Handle()).Should().NotThrow();
    }
    
}