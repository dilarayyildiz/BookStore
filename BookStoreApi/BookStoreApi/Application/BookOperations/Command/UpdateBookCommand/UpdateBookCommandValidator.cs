using FluentValidation;

namespace BookStoreApi.Application.BookOperations.Command.UpdateBookCommand;

public class UpdateBookCommandValidator : AbstractValidator<Command.UpdateBookCommand.UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(command => command.BookId).GreaterThan(0);
        RuleFor(command => command.Model.GenreId).GreaterThan(0);
        RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
    }
    
}