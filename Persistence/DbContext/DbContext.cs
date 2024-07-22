namespace Infrastructure.DbContext;

using Microsoft.EntityFrameworkCore;
using WebServiceWithoutMediatr.Entities;

public class FakeDbContext : DbContext
{
	public DbSet<Person> Persons { get; set; }

	public FakeDbContext(DbContextOptions<FakeDbContext> options)
		: base(options)
	{
		Database.EnsureCreated();
	}
    
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var myDatabaseName = "mydatabase_"+DateTime.Now.ToFileTimeUtc();
		optionsBuilder.UseLazyLoadingProxies();
		optionsBuilder.UseInMemoryDatabase(myDatabaseName);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Person>().HasData(
			new Person { Id = 1, Name = "Tom", Surname = "Smith" },
			new Person { Id = 2, Name = "Bob", Surname = "Magnusson"  }
		);
	}
}