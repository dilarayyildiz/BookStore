using AutoMapper;
using BookStoreApi.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Application.AuthorOperations.Queries.GetAuthors;

public class GetAuthorsQuery
{
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;
    public int AuthorId { get; set; }

    public GetAuthorsQuery(IBookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public List<AuthorsViewModel> Handle()
    {
        var authors = _context.Authors
            .Include(a => a.Books) // Kitapları dahil et
            .ToList();
        var authorsViewModel = _mapper.Map<List<AuthorsViewModel>>(authors);
        return authorsViewModel;
    }
    
}

public class AuthorsViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
}