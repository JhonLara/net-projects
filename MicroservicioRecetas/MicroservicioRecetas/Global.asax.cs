using Microservicio_Personas.Application.Services;
using Microservicio_Personas.Infrastructure.Repository;
using MicroservicioRecetas.Domain.Intefces;
using MicroservicioRecetas.Repository;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Text;

namespace MicroservicioRecetas
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new SimpleInjector.Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            RegisterDependencies(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            StartListening();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        private void RegisterDependencies(SimpleInjector.Container container)
        {
            container.Register<RecetaContext>(Lifestyle.Scoped);
            container.Register<IRecetaService, RecetaService>(Lifestyle.Scoped);
            container.Register<IRecetaRepository, RecetaRepository>(Lifestyle.Scoped);
        }
        private void StartListening()
        {
            // Ejecutamos la lógica de escucha de citas en un hilo o tarea en segundo plano
            Task.Run(() => ListenForMessages());
        }

        private void ListenForMessages()
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "citasQueue",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);

                        // Aquí puedes hacer algo con el mensaje recibido
                        // Ejemplo: procesar la cita
                        Console.WriteLine("Cita recibida: " + message);
                    };

                    channel.BasicConsume(queue: "citasQueue",
                                         autoAck: true,
                                         consumer: consumer);

                    // Mantener la tarea en ejecución sin bloquear la app
                    while (true)
                    {
                        Thread.Sleep(1000000); // O lo que sea necesario para mantener vivo el hilo
                    }
                }
            }
            catch (Exception ex)
            {
                // Maneja el error de la conexión, por ejemplo, logueando el error
                Console.WriteLine("Error al escuchar citas: " + ex.Message);
            }
        }
    }
}
