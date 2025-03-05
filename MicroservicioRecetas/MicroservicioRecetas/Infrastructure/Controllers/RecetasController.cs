using Microservicio_Personas.Application.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace MicroservicioRecetas.Infrastructure.Controllers
{
    [RoutePrefix("api/recetas")]
    public class RecetasController : ApiController
    {
        private readonly IRecetaService recetaService;


        public RecetasController(IRecetaService recetaService)
        {
            this.recetaService = recetaService;
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll() {
            return Ok(await recetaService.GetAll());
        }


        [HttpGet]
        [Route("escuchar")]
        public IHttpActionResult EscucharCitas()
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
                    };

                    channel.BasicConsume(queue: "citasQueue",
                                         autoAck: true, 
                                         consumer: consumer);

                    while (true)
                    {
                        Thread.Sleep(1000); 
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
