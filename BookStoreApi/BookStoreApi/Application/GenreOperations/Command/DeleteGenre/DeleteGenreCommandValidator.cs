using FluentValidation;

namespace BookStoreApi.Application.GenreOperations.Command.DeleteGenre;

public class DeleteGenreCommandValidator :AbstractValidator<DeleteGenreCommand>
{
    public DeleteGenreCommandValidator()
    {
        RuleFor(command => command.GenreId).GreaterThan(0);
    }
    
}