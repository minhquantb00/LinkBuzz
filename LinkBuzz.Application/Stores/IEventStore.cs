using LinkBuzz.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Stores
{
    public interface IEventStore<T> where T : class
    {
        Task SaveEventAsync(long objectId, IEnumerable<BaseEvent> events, int expectedVersion);
        Task<IEnumerable<BaseEvent>> GetEventsAsync(long objectId);
    }
}
