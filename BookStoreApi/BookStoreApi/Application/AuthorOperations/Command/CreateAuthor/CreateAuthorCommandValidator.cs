using FluentValidation;

namespace BookStoreApi.Application.AuthorOperations.Command.CreateAuthor;

public class CreateAuthorCommandValidator :AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
        RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(4);
        RuleFor(command => command.Model.BirthDate).NotEmpty().LessThan(DateTime.Now.Date);
    }
    
}
