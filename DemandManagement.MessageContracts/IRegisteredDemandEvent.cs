using System;
using System.Collections.Generic;
using System.Text;

namespace DemandManagement.MessageContracts
{
  public  interface IRegisteredDemandEvent
    {
        public Guid DemandId { get; set; }
    }
}
