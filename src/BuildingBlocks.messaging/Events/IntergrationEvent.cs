using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.messaging.Events
{
    public class IntergrationEvent // for common events , all other event will inherit this event
    {
        public Guid Id=>Guid.NewGuid();
        public DateTime OccuredOn=DateTime.Now;
        public string EventType => GetType().AssemblyQualifiedName;
    }
}
