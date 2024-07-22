namespace Application.Handlers.Person;

using FluentValidation;

public class PostPersonValidator : AbstractValidator<PostPersonCommand>
{
	public PostPersonValidator()
	{
		RuleFor(command => command.PersonDto.Id)
			.Must(id => id is null)
			.WithMessage("Идентификатор должен быть null");

		RuleFor(command => command.PersonDto.Name)
			.Must(name => !string.IsNullOrEmpty(name))
			.WithMessage("Отсутствует имя");

		RuleFor(command => command.PersonDto.Surname)
			.Must(surname => !string.IsNullOrEmpty(surname))
			.WithMessage("Отсутствует фамилия");
	}
}