using FluentValidation;

namespace BookStoreApi.Application.GenreOperations.Command.CreateGenre;

public class CreateGenreCommandValidator :AbstractValidator<CreateGenreCommand>
{
    public CreateGenreCommandValidator()
    {
        RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
    }
    
}