using DemandManagement.MessageContracts;
using GreenPipes;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemandManagement.Registration
{
    public class RegisterDemandCommandConsumer : IConsumer<IRegisterDemandCommand>
    {
        public Task Consume(ConsumeContext<IRegisterDemandCommand> context)
        {
            var message = context.Message;
            var guid = Guid.NewGuid();
            Console.WriteLine($"Demand successfully  registered. Subject:{message.Subject}, Description:{message.Description}, Id:{guid}");
            context.Publish<IRegisteredDemandEvent>(new
            {
                DemandId = guid
            });
            return Task.CompletedTask;
        }
    }
}
