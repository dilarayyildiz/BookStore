using AutoMapper;
using BookStoreApi.Application.GenreOperations.Queries.GetGenreDetail;
using BookStoreApi.DBOperations;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.GenreOperations.Queries;

public class GetGenreDetailQueryTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public GetGenreDetailQueryTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }
    [Fact]
    public void WhenGivenGenreIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
    {
        GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
        query.GenreId = 0;

        FluentActions
                .Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Genre not found");
    }
    [Fact]
    public void WhenGivenGenreIdIsinDB_InvalidOperationException_ShouldNotBeReturn()
    {
        GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
        query.GenreId = 1;

        FluentActions.Invoking(() => query.Handle()).Invoke();

        var genre = _context.Genres.SingleOrDefault(genre => genre.Id == query.GenreId);
        genre.Should().NotBeNull();
    }
    
}