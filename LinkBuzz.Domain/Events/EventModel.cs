using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Events
{
    public class EventModel
    {
        public string Id { get; set; }
        public DateTime Timestamp { get; set; }
        public long ObjectId { get; set; }
        public string ObjectType { get; set; }
        public int Version { get; set; }
        public string EventType { get; set; }
        public BaseEvent EventData { get; set; }
    }
}
