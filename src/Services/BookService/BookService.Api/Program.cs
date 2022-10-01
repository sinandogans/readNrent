using BookService.Application.Extensions.IoC;
using BookService.Infrastructure.Extensions.IoC;
using BookService.Persistence.Extensions.IoC;
using BookService.Persistence.MongoDbDriver.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<MongoDbOptions>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddApplicationRegistration();
builder.Services.AddPersistenceRegistration();
builder.Services.AddInfrastructureRegistration();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
