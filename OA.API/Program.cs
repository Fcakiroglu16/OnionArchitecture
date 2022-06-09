using System.Reflection;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OA.Application.Mappers;
using OA.Domain.Events;
using OA.Domain.Repositories;
using OA.Persistence;
using OA.Persistence.Consumers;
using OA.Persistence.Databases;
using OA.Persistence.MessageBroker;
using OA.Persistence.ReadRepositories;
using OA.Persistence.WriteMongoRepositories;
using OA.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddApplicationPart(Assembly.GetAssembly(typeof(CustomControllerBase)));

builder.Services.AddMediatR(Assembly.GetAssembly(typeof(ObjectMapper)));

builder.Services.Configure<ReadDatabaseSettings>(builder.Configuration.GetSection("ReadDatabaseSettings"));

builder.Services.AddSingleton<IReadDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<ReadDatabaseSettings>>().Value;
});

builder.Services.AddScoped<IWriteRepositoryManager, WriteRepositoryManager>();
builder.Services.AddScoped<IReadRepositoryManager, ReadRepositoryManager>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    //TODO: use RDMS 
    // options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));

    options.UseInMemoryDatabase("db");
});

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<SyncReadProductsConsumer>();
    x.AddConsumer<SyncReadCategoriesConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri(builder.Configuration.GetConnectionString("RabbitMQCon")), host => { });

        cfg.ReceiveEndpoint(EventPublish.SyncDatabaseQueue, e =>
        {
            e.ConfigureConsumer<SyncReadProductsConsumer>(context);
            e.ConfigureConsumer<SyncReadCategoriesConsumer>(context);
        });
    });
});
builder.Services.AddMassTransitHostedService();
builder.Services.AddScoped<IEventPublish, EventPublish>();
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