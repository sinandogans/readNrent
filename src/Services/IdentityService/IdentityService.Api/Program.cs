using IdentityService.Application.Extensions.IoC;
using IdentityService.Application.Utilities.Configuration;
using IdentityService.Infrastructure.Extensions.IoC;
using IdentityService.Persistence.Extensions.IoC;

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
