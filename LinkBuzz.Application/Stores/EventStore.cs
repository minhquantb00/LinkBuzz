using LinkBuzz.Application.Kafka.Producers;
using LinkBuzz.Domain.Domain;
using LinkBuzz.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Stores
{
    public class EventStore<T> : IEventStore<T> where T : class
    {
        private readonly IEventStoreRepository<T> _eventStoreRepository;
        private readonly IEventProducer _eventProducer;
        public EventStore(IEventStoreRepository<T> eventStoreRepository, IEventProducer eventProducer)
        {
            _eventStoreRepository = eventStoreRepository;
            _eventProducer = eventProducer;
        }

        public async Task<IEnumerable<BaseEvent>> GetEventsAsync(long objectId)
        {
            var eventStream = await _eventStoreRepository.FindByAggregateId(objectId);
            if (eventStream == null || eventStream.Any())
            {
                throw new ArgumentException("Incorrect post ID provided!");
            }
            return eventStream.ToList();
        }

        public async Task SaveEventAsync(long objectId, IEnumerable<BaseEvent> events, int expectedVersion)
        {
            var eventStream = await _eventStoreRepository.FindByAggregateId(objectId);
            if (expectedVersion != -1 && eventStream[^1].Version != expectedVersion)
            {
                throw new Exception();
            }
            var version = expectedVersion;
            foreach (var @event in events)
            {
                version++;
                @event.Version = version;
                var eventType = @event.GetType().Name;
                var eventModel = new EventModel
                {
                    Timestamp = DateTime.Now,
                    ObjectId = objectId,
                    Version = version,
                    EventType = eventType,
                    EventData = @event
                };
                await _eventStoreRepository.SaveAsync(eventModel);

                var topic = Environment.GetEnvironmentVariable("KAFKA_TOPIC");
                await _eventProducer.ProducerAsync(topic, @event);
            }
        }
    }
}
