namespace Infrastructure.Services;

using DbContext;

using WebServiceWithoutMediatr.Entities;

public class PersistentBaseRepository<T> : BaseRepository<T>
	where T: class, IPersistanceEntity
{
	public PersistentBaseRepository(FakeDbContext fakeDbContext) : base(fakeDbContext)
	{
	}

	public override IQueryable<T> GetAll()
	{
		return base.GetAll().Where(x => x.IsDeleted == false);
	}
}