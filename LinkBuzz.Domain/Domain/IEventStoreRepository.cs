using LinkBuzz.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Domain
{
    public interface IEventStoreRepository<T> where T : class
    {
        Task SaveAsync(T @event);
        Task<List<T>> FindByAggregateId(long objectId);
    }
}
