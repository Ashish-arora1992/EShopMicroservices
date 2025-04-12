using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.messaging.Events
{
    public class BasketCheckoutEvent:IntergrationEvent
    {
        public string UserName { get; set; }
    }
}
