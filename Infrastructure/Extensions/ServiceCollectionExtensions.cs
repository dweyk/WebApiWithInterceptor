namespace Infrastructure.Extensions;

using Application.Interfaces;
using Services;
using Microsoft.Extensions.DependencyInjection;
using WebServiceWithoutMediatr.Entities;
using WebServiceWithoutMediatr.Interfaces;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection InstallInfrastructureModule(this IServiceCollection services)
	{
		services.AddScoped(typeof(IDomainService<>), typeof(BaseDomainService<>));
		services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
		services.AddScoped(typeof(IDomainServiceInterceptor<>), typeof(BaseDomainServiceInterceptor<>));

		services.AddScoped<IDomainServiceInterceptor<Person>, PersonDomainServiceInterceptor>();
		services.AddScoped<IPersonService, PersonService>();

		services.AddScoped(typeof(IRepository<>), typeof(PersistentBaseRepository<>));

		return services;
	}
}