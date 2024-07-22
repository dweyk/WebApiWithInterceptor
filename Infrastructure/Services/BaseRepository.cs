namespace Infrastructure.Services;

using DbContext;
using Microsoft.EntityFrameworkCore;
using WebServiceWithoutMediatr.Interfaces;

public class BaseRepository<T> : IRepository<T>
	where T: class
{
	private readonly FakeDbContext _fakeDbContext;
	private readonly DbSet<T> _dbSet;

	public BaseRepository(FakeDbContext fakeDbContext)
	{
		_fakeDbContext = fakeDbContext;
		_dbSet = fakeDbContext.Set<T>();
	}

	public virtual IQueryable<T> GetAll()
		=> _dbSet.AsTracking();

	public async Task Save(T value)
	{
		await _dbSet.AddAsync(value);
		await _fakeDbContext.SaveChangesAsync();
	}

	public void Evict(T entity)
	{
		throw new NotImplementedException();
	}

	public Task Delete(object id)
	{
		throw new NotImplementedException();
	}

	public T Get(object id)
	{
		throw new NotImplementedException();
	}

	public T Load(object id)
	{
		throw new NotImplementedException();
	}

	public Task Update(T value)
	{
		throw new NotImplementedException();
	}
}