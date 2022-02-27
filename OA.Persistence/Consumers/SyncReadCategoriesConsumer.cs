using MassTransit;
using OA.Domain.Events;

namespace OA.Persistence.Consumers
{
    public class SyncReadCategoriesConsumer : IConsumer<SyncCategoriesEvent>
    {
        private readonly AppDbContext _context;

        public SyncReadCategoriesConsumer(AppDbContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<SyncCategoriesEvent> context)
        {
            switch (context.Message.Action)
            {
                case ESyncDatabaseAction.Created:
                    await _context.Categories.AddAsync(context.Message.Category);

                    break;

                case ESyncDatabaseAction.Updated:
                    break;

                case ESyncDatabaseAction.Deleted:
                    break;

                default:
                    break;
            }

            await _context.SaveChangesAsync();
        }
    }
}