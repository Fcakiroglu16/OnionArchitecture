using MassTransit;
using OA.Domain.Events;
using OA.Persistence.Databases;

namespace OA.Persistence.Consumers;

public class SyncReadProductsConsumer : IConsumer<SyncProductsEvent>
{
    private readonly AppDbContext _context;

    public SyncReadProductsConsumer(AppDbContext context)
    {
        _context = context;
    }

    public async Task Consume(ConsumeContext<SyncProductsEvent> context)
    {
        switch (context.Message.Action)
        {
            case ESyncDatabaseAction.Created:
                await _context.Products.AddAsync(context.Message.Product!);
                break;

            case ESyncDatabaseAction.Updated:
                _context.Products.Update(context.Message.Product!);
                break;

            case ESyncDatabaseAction.Deleted:
                _context.Products.Remove(context.Message.Product!);
                break;
        }

        await _context.SaveChangesAsync();
    }
}