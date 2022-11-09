using LibraryService.Application.Extensions.IoC;
using LibraryService.Application.Utilities.Configuration;
using LibraryService.Infrastructure.Extensions.IoC;
using LibraryService.Persistence.Extensions.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationHelper.Config = builder.Configuration;
builder.Services.AddControllers();
builder.Services.AddPersistenceRegistration();
builder.Services.AddApplicationRegistration();
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