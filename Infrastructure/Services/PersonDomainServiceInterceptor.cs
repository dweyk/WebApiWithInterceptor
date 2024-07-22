namespace Infrastructure.Services;

using WebServiceWithoutMediatr.Entities;
using WebServiceWithoutMediatr.Interfaces;

public class PersonDomainServiceInterceptor : BaseDomainServiceInterceptor<Person>
{
	public override bool BeforeCreateAction(IDomainService<Person> service, Person entity)
	{
		var isExist = service
			.GetAll()
			.Any(person => person.Name == entity.Name && person.Surname == entity.Surname);

		if (isExist)
			return false;

		return true;
	}

	public override bool AfterCreateAction(IDomainService<Person> service, Person entity)
	{
		// доп логика после создания
		return true;
	}
}