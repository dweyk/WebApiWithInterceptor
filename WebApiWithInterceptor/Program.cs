using Application.Extensions;
using Infrastructure.Extensions;
using MediatR;
using Persistence.Extensions;
using WebServiceWithoutMediatr.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.InstallPersistenceModule();
builder.Services.InstallInfrastructureModule();
builder.Services.InstallApplicationModule();

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
