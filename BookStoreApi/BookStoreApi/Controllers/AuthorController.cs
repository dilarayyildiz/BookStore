using AutoMapper;
using BookStoreApi.Application.AuthorOperations.Command.CreateAuthor;
using BookStoreApi.Application.AuthorOperations.Command.DeleteAuthor;
using BookStoreApi.Application.AuthorOperations.Command.UpdateAuthor;
using BookStoreApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStoreApi.Application.AuthorOperations.Queries.GetAuthors;
using BookStoreApi.DBOperations;
using BookStoreApi.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly BookStoreDbContext _context;
    
    private readonly IMapper _mapper;
    public AuthorController(BookStoreDbContext context ,IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }
    [HttpGet]
    public IActionResult GetAuthors()
    {
        GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
        var authors = query.Handle();
        return Ok(authors);
    }
    [HttpGet("{id}")]
    public IActionResult GetAuthorById(int id)
    {
        GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
        query.AuthorId = id;

        GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
        validator.ValidateAndThrow(query);

        var author = query.Handle();
        return Ok(author);
    }


    [HttpPost]
    public IActionResult AddAuthor([FromBody] CreateAuthorCommand.CreateAuthorModel newAuthor)
    {
        CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
        command.Model = newAuthor;

        CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updatedAuthor)
    {
        
        UpdateAuthorCommand command = new UpdateAuthorCommand(_context , _mapper);
        command.AuthorId = id;
        command.Model = updatedAuthor;

        UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
        
        
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id)
    {
        try
        {
            
            var books = _context.Books.Where(b => b.AuthorId == id).ToList();

            if (books.Any())
            {
                _context.Books.RemoveRange(books);
                _context.SaveChanges();
            }

            
            var author = _context.Authors.SingleOrDefault(a => a.Id == id);
            if (author == null)
            {
                return NotFound("Author not found.");
            }

            _context.Authors.Remove(author);
            _context.SaveChanges();

            return Ok("Author and associated books deleted.");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
            
        
        
    }
    
}