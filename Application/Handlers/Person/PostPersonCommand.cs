namespace Application.Handlers.Person;

using MediatR;
using WebServiceWithoutMediatr.Models;

public class PostPersonCommand : IRequest<PostPersonResult>
{
	public PersonDto PersonDto { get; }

	public PostPersonCommand(PersonDto personDto) => PersonDto = personDto;
}