using AutoMapper;
using BookStoreApi.DBOperations;
using BookStoreApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Application.BookOperations.Queries.GetBooks;

public class GetBooksQuery
{
    private readonly IBookStoreDbContext _dbContext;
    private readonly  IMapper _mapper;
    public GetBooksQuery(IBookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public List<BooksViewModel> Handle()
    {
        var bookList = _dbContext.Books.Include(x => x.Genre).OrderBy(x => x.Id).ToList<Book>();
        List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
        
        return vm;
    }
}
public class BooksViewModel 
{ 
    public string Title { get; set; }
    public int PageCount { get; set; }
    public string PublishDate { get; set; } 
    public string Genre { get; set; }
}
    

        
