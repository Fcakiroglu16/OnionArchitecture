using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OA.Domain.Repositories;
using OA.Persistence;
using OA.Persistence.Databases;
using OA.Persistence.Repositories;
using OA.Persistence.WriteMongoRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddApplicationPart(Assembly.GetAssembly(typeof(OA.Presentation.CustomControllerBase)));

builder.Services.AddMediatR(Assembly.GetAssembly(typeof(OA.Application.Mappers.ObjectMapper)));

builder.Services.Configure<ReadDatabaseSettings>(builder.Configuration.GetSection("ReadDatabaseSettings"));

builder.Services.AddSingleton<IReadDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<ReadDatabaseSettings>>().Value;
});

builder.Services.AddScoped<IWriteRepositoryManager, WriteRepositoryManager>();

//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
//});

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