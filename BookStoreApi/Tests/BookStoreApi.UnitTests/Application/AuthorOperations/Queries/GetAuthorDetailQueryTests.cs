using AutoMapper;
using BookStoreApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStoreApi.DBOperations;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.AuthorOperations.Queries;

public class GetAuthorDetailQueryTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public GetAuthorDetailQueryTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }

    [Fact]
    public void WhenNotFoundAuthorIdIsGiven_InvalidOperationException_ShouldBeReturn()
    {
        // Arrange
        GetAuthorDetailQuery query = new(_context, _mapper);
        query.AuthorId = 0;

        // Act & Assert
        FluentActions
            .Invoking(() => query.Handle())
            .Should()
            .Throw<InvalidOperationException>()
            .And
            .Message.Should()
            .Be("Yazar bulunamadı.");
    }
    [Fact]
    public void WhenValidAuthorIdIsGiven_Author_ShouldBeReturn()
    {
        // Arrange
        GetAuthorDetailQuery query = new(_context, _mapper);
        query.AuthorId = 1;

        // Act
        FluentActions.Invoking(() => query.Handle()).Invoke();

        // Assert
        var author = _context.Authors.SingleOrDefault(author => author.Id == query.AuthorId);
        author.Should().NotBeNull();
    }
    
}