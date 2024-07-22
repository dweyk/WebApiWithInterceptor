namespace WebServiceWithoutMediatr.Entities;

public interface IPersistanceEntity
{
	public bool IsDeleted { get; set; }
}