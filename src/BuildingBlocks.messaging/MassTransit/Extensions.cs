using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.messaging.MassTransit
{
    public static class Extensions
    {
        public static IServiceCollection AddMessageBroker(this IServiceCollection Services,IConfiguration configuration,Assembly? assembly=null)
        {
            Services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter(); // Standardized queue names
                if (assembly != null) // if provided register all the consumers from that assemble instead of manually register each one
                    x.AddConsumers(assembly);
                // Configure RabbitMQ Transport
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri(configuration["MessageBroker:Host"]), h =>
                    {
                        h.Username(configuration["MessageBroker:UserName"]);
                        h.Password(configuration["MessageBroker:UserName"]);
                    });

                    cfg.ConfigureEndpoints(context); // Auto-configure consumers
                });
            });
            
            return Services;
        }
    }
}
