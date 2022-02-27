namespace OA.Domain.Events
{
    public interface IEventPublish
    {
        Task Publish<T>(T @event);
    }
}