using AutoMapper;
using BookStoreApi.Application.AuthorOperations.Command.UpdateAuthor;
using BookStoreApi.DBOperations;
using BookStoreApi.UnitTests.TestsSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.AuthorOperations.Command.UpdateAuthor;

public class UpdateAuthorCommandTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private IMapper _mapper;

    public UpdateAuthorCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }
    [Fact]
    public void WhenAuthorIdIsInvalid_InvalidOperationException_ShouldBeReturn()
    {
        UpdateAuthorCommand command = new UpdateAuthorCommand(_context, _mapper);
        command.AuthorId = 0;
        FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı");
    }
    [Fact]
    public void WhenAuthorIdIsInvalid_InvalidOperationException_ShouldBeReturn2()
    {
        UpdateAuthorCommand command = new UpdateAuthorCommand(_context, _mapper);
        command.AuthorId = 1;
        FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı");
    }
    
}