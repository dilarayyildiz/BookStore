using AutoMapper;
using BookStoreApi.Application.BookOperations.Command.CreateBook;
using BookStoreApi.Application.BookOperations.Command.DeleteBook;
using BookStoreApi.Application.BookOperations.Command.UpdateBookCommand;
using BookStoreApi.Application.BookOperations.Queries.GetBookDetail;
using BookStoreApi.Application.BookOperations.Queries.GetBooks;
using BookStoreApi.DBOperations;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static BookStoreApi.Program;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly BookStoreDbContext _context;
    
    private readonly IMapper _mapper;
    
    public BookController(BookStoreDbContext context ,IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        GetBooksQuery query = new GetBooksQuery(_context , _mapper);
        var result = query.Handle();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    { 
        BookDetailViewModel result;
        GetBookDetailQuery query = new GetBookDetailQuery(_context , _mapper);
        query.BookId = id;
        GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
        validator.ValidateAndThrow(query);
        result = query.Handle();
        
        return Ok(result);
    }
    
    
    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookModel newBook)
    {
        CreateBookCommand command = new CreateBookCommand(_context, _mapper); 
        command.Model = newBook;
        CreateBookCommandValidator validator = new CreateBookCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
            
        
        return Ok(); 
        
    }
    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
    {
        UpdateBookCommand command = new UpdateBookCommand(_context);
        command.BookId = id;
        command.Model = updatedBook;
        
        UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle(id);
        
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        DeleteBookCommand command = new DeleteBookCommand(_context);
        command.BookId = id;
        DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        
        return Ok();
    }
    
}