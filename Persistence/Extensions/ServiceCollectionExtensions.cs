namespace Persistence.Extensions;

using Infrastructure.DbContext;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection InstallPersistenceModule(this IServiceCollection services)
	{
		services.AddDbContext<FakeDbContext>();

		return services;
	}
}