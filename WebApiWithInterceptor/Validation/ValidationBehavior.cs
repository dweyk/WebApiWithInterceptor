namespace WebServiceWithoutMediatr.Validation;

using FluentValidation;

using MediatR;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : IRequest<TResponse>
{
	private readonly ILogger<ValidationBehaviour<TRequest, TResponse>> _logger;
	private readonly IEnumerable<IValidator<TRequest>> _validators;

	public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators,
		ILogger<ValidationBehaviour<TRequest, TResponse>> logger)
	{
		_validators = validators;
		_logger = logger;
	}

	public async Task<TResponse> Handle(
		TRequest request,
		RequestHandlerDelegate<TResponse> next,
		CancellationToken cancellationToken)
	{
		if (_validators.Any())
		{
			var typeName = request.GetType().Name;

			_logger.LogInformation("Validating command {CommandType}", typeName);

			var context = new ValidationContext<TRequest>(request);

			var validationResults =
				await Task.WhenAll(_validators.Select(validator => validator.ValidateAsync(context, cancellationToken)));

			var failures = validationResults.SelectMany(result => result.Errors)
				.Where(error => error != null).ToList();
			if (failures.Any())
			{
				_logger.LogWarning(
					"Validation errors - {CommandType} - Command: {@Command} - Errors: {@ValidationErrors}",
					typeName, request, failures);

				throw new ValidationException("Validation exception", failures);
			}
		}

		return await next();
	}
}