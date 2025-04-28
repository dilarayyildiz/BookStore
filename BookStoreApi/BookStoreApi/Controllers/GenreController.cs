using AutoMapper;
using BookStoreApi.Application.GenreOperations.Command.CreateGenre;
using BookStoreApi.Application.GenreOperations.Command.DeleteGenre;
using BookStoreApi.Application.GenreOperations.Command.UpdateGenre;
using BookStoreApi.Application.GenreOperations.Queries.GetGenreDetail;
using BookStoreApi.Application.GenreOperations.Queries.GetGenres;
using BookStoreApi.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class GenreController : ControllerBase
{
    private readonly BookStoreDbContext _context;
    
    private readonly IMapper _mapper;
    public GenreController(BookStoreDbContext context ,IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }
    [HttpGet]
    public IActionResult GetGenres()
    {
        GetGenresQuery query = new GetGenresQuery(_context , _mapper);
        var obj = query.Handle();
        return Ok(obj);
    }
    [HttpGet("{id}")]
    public IActionResult GetGenreDetail(int id)
    {
        GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
        query.GenreId = id;
        GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
        validator.ValidateAndThrow(query);
        
        var obj = query.Handle();
        return Ok(obj);
    }
    [HttpPost]
    public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
    {
        CreateGenreCommand command = new CreateGenreCommand(_context);
        command.Model = newGenre;
        
        CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
        validator.ValidateAndThrow(command);
        
        command.Handle();
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updateGenre)
    {
        UpdateGenreCommand command = new UpdateGenreCommand(_context);
        command.GenreId = id;
        command.Model = updateGenre;
        
        UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteGenre(int id)
    {
        DeleteGenreCommand command = new DeleteGenreCommand(_context);
        command.GenreId = id;
        
        DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
        validator.ValidateAndThrow(command);
        
        command.Handle();
        return Ok();
    }
}