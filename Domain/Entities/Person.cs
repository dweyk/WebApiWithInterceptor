namespace WebServiceWithoutMediatr.Entities;

public class Person : IPersistanceEntity
{
	public virtual long Id { get; set; }
	public virtual string Name { get; set; }
	public virtual string Surname { get; set; }

	public bool IsDeleted { get; set; }
}