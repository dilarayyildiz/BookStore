using AutoMapper;
using BookStoreApi.DBOperations;

namespace BookStoreApi.Application.AuthorOperations.Command.UpdateAuthor;

public class UpdateAuthorCommand
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public int AuthorId { get; set; }
    public UpdateAuthorModel Model { get; set; }

    public UpdateAuthorCommand(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public void Handle()
    {
        var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
        if (author is null)
            throw new InvalidOperationException("Author not found");

        author.Name = Model.Name != default ? Model.Name : author.Name;
        author.Surname = Model.Surname != default ? Model.Surname : author.Surname;
        author.BirthDate = Model.BirthDate != default ? Model.BirthDate : author.BirthDate;

        _context.SaveChanges();
    }

    
}

public class UpdateAuthorModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
}