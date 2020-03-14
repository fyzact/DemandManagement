using MassTransit;
using MassTransit.RabbitMqTransport;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemandManagement.MessageContracts
{

    public static class BusConfigurator
    {
        public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
             {
                 var host = cfg.Host(new Uri(RabbitMqConsts.RabbitMqUri), hst =>
                 {
                     hst.Username(RabbitMqConsts.UserName);
                     hst.Password(RabbitMqConsts.Password);
                 });
               
                 registrationAction?.Invoke(cfg, host);
             });
        }
    }

}
