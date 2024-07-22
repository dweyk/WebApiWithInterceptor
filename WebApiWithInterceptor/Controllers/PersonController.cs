namespace WebServiceWithoutMediatr.Controllers;

using Application.Handlers.Person;
using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
	private readonly IPersonService _personService;
	private readonly ILogger<PersonController> _logger;
	private readonly IMediator _mediator;

	public PersonController(ILogger<PersonController> logger,
		IPersonService personService,
		IMediator mediator)
	{
		_logger = logger;
		_personService = personService;
		_mediator = mediator;
	}

	[HttpPost("TestSave")]
	public async Task<IActionResult> TestSave(PersonDto personDto)
	{
		var result = await _personService.SaveAsync(personDto);
		return Ok(result);
	}

	[HttpPost("TestSaveWithMediatr")]
	public async Task<IActionResult> TestSaveWithMediatr(PersonDto personDto)
	{
		var command = new PostPersonCommand(personDto);
		var result = await _mediator.Send(command);
		return Ok(result);
	}
}