using AutoMapper;
using BookStoreApi.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Application.BookOperations.Queries.GetBookDetail;

public class GetBookDetailQuery
{   
    private readonly IBookStoreDbContext _dbContext;
    private readonly  IMapper _mapper;
    public int BookId { get; set; }

    public GetBookDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public BookDetailViewModel Handle()
    {
        var book = _dbContext.Books.Include(x => x.Genre).Where(x => x.Id == BookId).SingleOrDefault();
        
        if (book is null)
            throw new InvalidOperationException("Kitap bulunamadı");
        
        BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book); 
    
        return vm;
    
    }
    
}
public class BookDetailViewModel
{   
    public string Title { get; set; }
    public int PageCount { get; set; }
    public string PublishDate { get; set; }
    public string Genre { get; set; }
}