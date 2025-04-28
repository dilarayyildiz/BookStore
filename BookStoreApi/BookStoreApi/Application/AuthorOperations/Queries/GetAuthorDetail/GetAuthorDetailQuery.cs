using AutoMapper;
using BookStoreApi.DBOperations;

namespace BookStoreApi.Application.AuthorOperations.Queries.GetAuthorDetail;

public class GetAuthorDetailQuery
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public int AuthorId { get; set; }
    public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /*public AuthorDetailViewModel Handle()
    {
        var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
        if (author is null)
            throw new InvalidOperationException("Yazar bulunamadı");
        
        return _mapper.Map<AuthorDetailViewModel>(author);
        
    }*/
    
    public AuthorDetailViewModel Handle()
    {
        var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
        if (author is null)
            throw new InvalidOperationException("Author not found.");

        AuthorDetailViewModel vm = _mapper.Map<AuthorDetailViewModel>(author);
        return vm;
    }
    
}

public class AuthorDetailViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
}