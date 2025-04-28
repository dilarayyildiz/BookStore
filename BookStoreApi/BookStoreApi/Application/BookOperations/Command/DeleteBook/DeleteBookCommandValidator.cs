using FluentValidation;

namespace BookStoreApi.Application.BookOperations.Command.DeleteBook;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(command => command.BookId).GreaterThan(0);
    }
    
}