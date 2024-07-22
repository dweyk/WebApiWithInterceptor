namespace Infrastructure.Services;

using WebServiceWithoutMediatr.Interfaces;

public class BaseDomainServiceInterceptor<T> : IDomainServiceInterceptor<T> where T : class
{
	public virtual bool BeforeCreateAction(IDomainService<T> service, T entity)
	{
		return true;
	}

	public virtual bool BeforeUpdateAction(IDomainService<T> service, T entity)
	{
		return true;
	}

	public virtual bool BeforeDeleteAction(IDomainService<T> service, T entity)
	{
		return true;
	}

	public virtual bool AfterCreateAction(IDomainService<T> service, T entity)
	{
		return true;
	}

	public virtual bool AfterUpdateAction(IDomainService<T> service, T entity)
	{
		return true;
	}

	public virtual bool AfterDeleteAction(IDomainService<T> service, T entity)
	{
		return true;
	}
}