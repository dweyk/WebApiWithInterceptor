namespace Infrastructure.Services;

using DbContext;

using WebServiceWithoutMediatr.Entities;

public class PersistentBaseDomainservice<T> : BaseDomainService<T> 
	where T : class, IPersistanceEntity
{
	public PersistentBaseDomainservice(IServiceProvider serviceProvider,
		FakeDbContext fakeDbContext) : base(serviceProvider, fakeDbContext)
	{
	}
}