namespace Infrastructure.Services;

using Application.Interfaces;
using WebServiceWithoutMediatr.Entities;
using WebServiceWithoutMediatr.Interfaces;
using WebServiceWithoutMediatr.Models;

public class PersonService : IPersonService
{
	private readonly IDomainService<Person> _personService;

	public PersonService(IDomainService<Person> personService)
	{
		_personService = personService;
	}

	public async Task<bool> SaveAsync(PersonDto personDto)
	{
		var person = new Person
		{
			Name = personDto.Name!,
			Surname = personDto.Name!,
		};

		return await _personService.Save(person);
	}
}