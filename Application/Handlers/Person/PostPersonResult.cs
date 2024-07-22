namespace Application.Handlers.Person;

public class PostPersonResult
{
	public bool Result { get; }

	public PostPersonResult(bool result) => Result = result;
}