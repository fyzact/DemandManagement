using System;

namespace DemandManagement.MessageContracts
{
    public interface IRegisterDemandCommand
    {
        public string Subject { get; set; }
        public string Description { get; set; }

    }
}
