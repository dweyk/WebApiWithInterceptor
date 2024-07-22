namespace Application.Extensions;

using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Handlers.Person;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection InstallApplicationModule(this IServiceCollection services)
	{
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

		services.AddValidatorsFromAssemblyContaining<PostPersonValidator>();

		services.AddFluentValidationAutoValidation();
		services.AddFluentValidationClientsideAdapters();

		return services;
	}
}