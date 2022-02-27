using MassTransit;
using OA.Domain.Events;

namespace OA.Persistence.MessageBroker
{
    public class EventPublish : IEventPublish
    {
        public const string SyncDatabaseQueue = "sync-database-queue";
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public EventPublish(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task Publish<T>(T @event)
        {
            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{SyncDatabaseQueue}"));

            await sendEndpoint.Send(@event);
        }
    }
}