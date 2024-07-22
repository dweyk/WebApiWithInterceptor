namespace Infrastructure.Services;

using DbContext;
using Microsoft.Extensions.DependencyInjection;
using WebServiceWithoutMediatr.Interfaces;

public class BaseDomainService<T> : IDomainService<T>
	where T: class
{
	private readonly IRepository<T>? _repository;
	private readonly IServiceProvider _serviceProvider;
	private readonly FakeDbContext _fakeDbContext;

	public BaseDomainService(IServiceProvider serviceProvider, FakeDbContext fakeDbContext)
	{
		_serviceProvider = serviceProvider;
		_fakeDbContext = fakeDbContext;
	}

	/// <summary>Репозиторий</summary>
	protected IRepository<T> Repository => this._repository ?? this._serviceProvider.GetRequiredService<IRepository<T>>();

	public T Get(object id)
	{
		throw new NotImplementedException();
	}

	public T Load(object id)
	{
		throw new NotImplementedException();
	}

	public Task<bool> Save(T value)
	{
		var result = this.InTransaction(() => this.SaveInternal(value));
		return Task.FromResult(result);
	}

	protected virtual bool SaveInternal(T value)
	{
		using var scope = _serviceProvider.CreateScope();
		var interceptors = scope.ServiceProvider.GetServices<IDomainServiceInterceptor<T>>().ToList();
		try
		{
			var result = this.CallBeforeSaveInterceptors(value, interceptors);
			if (!result)
				return false;

			this.SaveEntityInternal(value);

			result = this.CallAfterSaveInterceptors(value, interceptors);

			return result;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message); //TODO logger
			return false;
		}
	}

	protected virtual bool InTransaction(Func<bool> action)
	{
		//using var dataTransaction = this._fakeDbContext.Database.BeginTransaction();
		try
		{
			var result =  action();
			//if (result) 
				//dataTransaction.Commit();

			return result;
		}
		catch (Exception ex1)
		{
			try
			{
				//dataTransaction.Rollback();
			}
			catch (Exception ex)
			{
				throw new Exception(
					string.Format(
						"Произошла неизвестная ошибка при откате транзакции: \r\nMessage: {0}; \r\nStackTrace:{1};",
						ex.Message, ex.StackTrace!), ex1);
			}
			throw;
		}
	}

	protected virtual void SaveEntityInternal(T entity) => this.Repository.Save(entity);

	protected virtual bool CallBeforeSaveInterceptors(T entity,
		IEnumerable<IDomainServiceInterceptor<T>> interceptors)
	{
		var result = true;

		foreach (IDomainServiceInterceptor<T> interceptor in interceptors)
		{
			result =  interceptor.BeforeCreateAction(this, entity);
		}

		return result;
	}

	protected virtual bool CallAfterSaveInterceptors(
		T entity,
		IEnumerable<IDomainServiceInterceptor<T>> interceptors)
	{
		var result = true;

		foreach (IDomainServiceInterceptor<T> interceptor in interceptors)
		{
			result = interceptor.AfterCreateAction(this, entity);
		}

		return result;
	}

	public Task Update(T value)
	{
		throw new NotImplementedException();
	}

	public Task Delete(object id)
	{
		throw new NotImplementedException();
	}

	public IQueryable<T> GetAll()
		=> Repository.GetAll();
}