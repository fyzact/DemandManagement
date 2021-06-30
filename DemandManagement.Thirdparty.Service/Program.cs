using DemandManagement.MessageContracts;
using GreenPipes;
using MassTransit;
using System;

namespace DemandManagement.Thirdparty.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ThirdParty";
           var bus=  BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(RabbitMqConsts.ThirdPartyServiceQueue, e =>
                {
                    e.Consumer<DemandRegisteredEventConsumer>();
                    e.UseRateLimit(1000, TimeSpan.FromMinutes(1));
                });
            });
            bus.StartAsync();
            Console.WriteLine("Listening for Demand registered events.. Press enter to exit");
            Console.ReadLine();
            bus.StopAsync();
        }
    }
}
