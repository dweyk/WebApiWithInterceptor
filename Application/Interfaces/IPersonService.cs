namespace Application.Interfaces;

using WebServiceWithoutMediatr.Models;

public interface IPersonService
{
	Task<bool> SaveAsync(PersonDto personDto);
}