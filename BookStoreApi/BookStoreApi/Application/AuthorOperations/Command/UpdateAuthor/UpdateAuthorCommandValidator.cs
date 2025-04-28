using FluentValidation;

namespace BookStoreApi.Application.AuthorOperations.Command.UpdateAuthor;

public class UpdateAuthorCommandValidator :AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(command => command.AuthorId).GreaterThan(0).WithMessage("Author ID must be greater than 0.");
        RuleFor(command => command.Model.Name).NotEmpty().WithMessage("Author Name is required.");
        RuleFor(command => command.Model.Surname).NotEmpty().WithMessage("Author Surname is required.");
        RuleFor(command => command.Model.BirthDate).NotEmpty().WithMessage("Birth Date is required.");
    }
    
}