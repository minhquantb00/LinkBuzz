using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Events
{
    public abstract class BaseEvent
    {
        public long Id { get; set; }
        protected BaseEvent(string type)
        {
            this.Type = type;
        }
        public int Version { get; set; }
        public string Type { get; set; }
    }
}
