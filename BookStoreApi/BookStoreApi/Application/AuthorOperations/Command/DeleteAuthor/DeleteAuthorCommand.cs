using BookStoreApi.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Application.AuthorOperations.Command.DeleteAuthor;

public class DeleteAuthorCommand
{
    private readonly IBookStoreDbContext _context;
    public int AuthorId { get; set; }   

    public DeleteAuthorCommand(IBookStoreDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var author = _context.Authors.SingleOrDefault(a => a.Id == AuthorId);

        if (author is null)
            throw new InvalidOperationException("Author not found.");

        // Kitaplar yayında ise yazar silinemez
        if (_context.Books.Any(b => b.AuthorId == AuthorId && b.IsActive))
        {
            throw new InvalidOperationException("Cannot delete an author with active books.");
        }

        _context.Authors.Remove(author);
        _context.SaveChanges();
    }
    
}