namespace WebServiceWithoutMediatr.Interfaces;

public interface IDomainServiceInterceptor<T> where T: class
{
	/// <summary>Метод вызывается перед созданием объекта</summary>
	/// <param name="service">Домен</param>
	/// <param name="entity">Объект</param>
	/// <returns>Результат выполнения</returns>
	bool BeforeCreateAction(IDomainService<T> service, T entity);

	/// <summary>Метод вызывается перед обновлением объекта</summary>
	/// <param name="service">Домен</param>
	/// <param name="entity">Объект</param>
	/// <returns>Результат выполнения</returns>
	bool BeforeUpdateAction(IDomainService<T> service, T entity);

	/// <summary>Метод вызывается перед удалением объекта</summary>
	/// <param name="service">Домен</param>
	/// <param name="entity">Объект</param>
	/// <returns>Результат выполнения</returns>
	bool BeforeDeleteAction(IDomainService<T> service, T entity);

	/// <summary>Метод вызывается после создания объекта</summary>
	/// <param name="service">Домен</param>
	/// <param name="entity">Объект</param>
	/// <returns>Результат выполнения</returns>
	bool AfterCreateAction(IDomainService<T> service, T entity);

	/// <summary>Метод вызывается после обновления объекта</summary>
	/// <param name="service">Домен</param>
	/// <param name="entity">Объект</param>
	/// <returns>Результат выполнения</returns>
	bool AfterUpdateAction(IDomainService<T> service, T entity);

	/// <summary>Метод вызывается после удаления объекта</summary>
	/// <param name="service">Домен</param>
	/// <param name="entity">Объект</param>
	/// <returns>Результат выполнения</returns>
	bool AfterDeleteAction(IDomainService<T> service, T entity);
}