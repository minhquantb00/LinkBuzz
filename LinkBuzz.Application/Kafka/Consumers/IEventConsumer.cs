using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Application.Kafka.Consumers
{
    public interface IEventConsumer
    {
        void Consume(string topic);
    }
}
