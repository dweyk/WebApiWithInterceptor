namespace Application.Handlers.Person;

using Interfaces;
using MediatR;

public class PostPersonHandler : IRequestHandler<PostPersonCommand, PostPersonResult>
{
	private readonly IPersonService _personService;

	public PostPersonHandler(IPersonService personService) => _personService = personService;

	public async Task<PostPersonResult> Handle(PostPersonCommand command, CancellationToken cancellationToken)
	{
		var result = await _personService.SaveAsync(command.PersonDto);
		return new PostPersonResult(result);
	}
}