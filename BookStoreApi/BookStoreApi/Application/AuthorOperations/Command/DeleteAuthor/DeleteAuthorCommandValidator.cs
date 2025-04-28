using FluentValidation;

namespace BookStoreApi.Application.AuthorOperations.Command.DeleteAuthor;

public class DeleteAuthorCommandValidator :AbstractValidator<DeleteAuthorCommand>
{
    public DeleteAuthorCommandValidator()
    {
        RuleFor(command => command.AuthorId).GreaterThan(0).WithMessage("Author ID must be greater than 0.");
    }
    
}