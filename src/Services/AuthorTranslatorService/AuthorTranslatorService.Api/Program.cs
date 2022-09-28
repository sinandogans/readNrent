using AuthorTranslatorService.Application.Extensions.IoC;
using AuthorTranslatorService.Persistence.Extensions.IoC;
using AuthorTranslatorService.Persistence.MongoDbDriver.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoDbOptions>(builder.Configuration.GetSection("MongoDB"));

builder.Services.AddControllers();
builder.Services.AddApplicationRegistration();
builder.Services.AddPersistenceRegistration();
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
