using AutoMapper;
using BookStoreApi.DBOperations;
using BookStoreApi.Entities;

namespace BookStoreApi.Application.BookOperations.Command.CreateBook;

public class CreateBookCommand 
{
    public CreateBookModel Model { get; set; } // dolu gelmesi için
    private readonly IBookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public CreateBookCommand(IBookStoreDbContext dbContext ,IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
        if (book is not null)
            throw new InvalidOperationException("Kitap zaten mevcut");

        book = _mapper.Map<Book>(Model);
     
        _dbContext.Books.Add(book);
        _dbContext.SaveChanges();
    }
}

public class CreateBookModel
{
    public string Title { get; set; }
    public int GenreId { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }
        
}