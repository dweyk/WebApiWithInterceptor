namespace WebServiceWithoutMediatr.Interfaces;

public interface IRepository<T>
{
	void Evict(T entity);

	/// <summary>Удалить объект</summary>
	/// <param name="id">Идентификатор объекта</param>
	Task Delete(object id);

	/// <summary>Получить объект</summary>
	/// <param name="id">Идентификатор объекта</param>
	/// <returns>Экземпляр объекта</returns>
	T Get(object id);

	/// <summary>
	/// Метод для формирования запроса
	/// </summary>
	/// <returns>Коллекцию объектов типа IQueryable</returns>
	IQueryable<T> GetAll();

	/// <summary>Получить прокси объекта</summary>
	/// <param name="id">Идентификатор объекта</param>
	/// <returns>Прокси объекта</returns>
	T Load(object id);

	/// <summary>Создать объект</summary>
	/// <param name="value">Создаваемый объект</param>
	Task Save(T value);

	/// <summary>Сохранить изменения объекта</summary>
	/// <param name="value">Сохраняемый объект</param>
	Task Update(T value);
}