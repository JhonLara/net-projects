using MicroservicioCitas.Application.dto;
using MicroservicioCitas.Application.Services;
using MicroservicioCitas.Domain.Entities;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MicroservicioCitas.Infrastructure.Controllers
{
    [RoutePrefix("api/citas")]
    public class CitasController : ApiController
    {
        private readonly ICitaService citaSevice;


        public CitasController(ICitaService citaSevice)
        {
            this.citaSevice = citaSevice;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            return Ok(await citaSevice.GetAll());
        }

        [HttpPost]
        [Route("enviar")]
        public IHttpActionResult EnviarCita([FromBody] string cita)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using(var connection = factory.CreateConnection())
                {
                    using(var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: "citasQueue",     
                                             durable: false,         
                                             exclusive: false,      
                                             autoDelete: false,     
                                             arguments: null);      

                        var body = Encoding.UTF8.GetBytes(cita);

                        channel.BasicPublish(exchange: "",
                                             routingKey: "citasQueue",  
                                             basicProperties: null,
                                             body: body);
                    }
                }
    

                return Ok("Cita enviada correctamente");
           
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var cita = await citaSevice.GetById(id);
            if (cita == null)
            {
                return NotFound();
            }
            return Ok(cita);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] CitaDTO cita)
        {
            var createdCita = await citaSevice.Create(cita);
            return Ok(createdCita);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] Cita cita)
        {
            if (cita == null)
            {
                return BadRequest("La cita no puede ser nula");
            }

            var updatedPersona = await citaSevice.Update(id, cita);
            if (updatedPersona == null)
            {
                return NotFound();
            }

            return Ok(updatedPersona);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var result = await citaSevice.Delete(id);
            if (!result)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
