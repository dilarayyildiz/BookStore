using BookStoreApi.BookOperations.CreateBook;
using BookStoreApi.BookOperations.DeleteBook;
using BookStoreApi.BookOperations.GetBookDetail;
using BookStoreApi.BookOperations.GetBooks;
using BookStoreApi.BookOperations.UpdateBookCommand;
using BookStoreApi.DBOperations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]'s")]
public class BookController : ControllerBase
{
    private readonly BookStoreDbContext _context;
    
    public BookController(BookStoreDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        GetBooksQuery query = new GetBooksQuery(_context);
        var result = query.Handle();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    { 
        GetBookDetailQuery.BookDetailViewModel result;
        try
        {
            GetBookDetailQuery query = new GetBookDetailQuery(_context);
            query.BookId = id;
            
            result = query.Handle();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
        return Ok(result);
    }
    
    
    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookCommand.CreateBookModel newBook)
    {
        CreateBookCommand command = new CreateBookCommand(_context); 
        try 
        {
            command.Model = newBook;
            command.Handle();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
        return Ok();
        
    }
    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] UpdateBookCommand.UpdateBookModel updatedBook)
    {
        try
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = id;
            command.Model = updatedBook;
            command.Handle();
        
        }
        catch (Exception ex)
        {
            return  BadRequest(ex.Message);
        }
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        try
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = id;
            command.Handle();
        }
        catch (Exception ex)
        {
            BadRequest(ex.Message);
        }
        return Ok();
    }
    
    
   
}