using AutoMapper;
using BookStoreApi.DBOperations;
using BookStoreApi.Entities;

namespace BookStoreApi.Application.GenreOperations.Command.CreateGenre;

public class CreateGenreCommand
{
    public CreateGenreModel Model { get; set; }
    private readonly IBookStoreDbContext _dbContext;
    private readonly IMapper _mapper;


    public CreateGenreCommand(IBookStoreDbContext dbContext ,IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        //_context = context;
       // _mapper = 
        
    }
    public void Handle()
    {
        var genre = _dbContext.Genres.SingleOrDefault(x => x.Name == Model.Name);
        if (genre is not null)
            throw new InvalidOperationException("Genre already exists");
        genre = new Genre();
        genre.Name = Model.Name;
        _dbContext.Genres.Add(genre);
        _dbContext.SaveChanges();
    }
    
}

public class CreateGenreModel
{
    public string Name { get; set; }
}