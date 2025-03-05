using Microservicio_Personas.Application.Services;
using Microservicio_Personas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MicroservicioPersonas.Infrastructure.Controllers
{
    [RoutePrefix("api/personas")]
    public class PersonaController : ApiController
    {
        private readonly IPersonaService personaService;
        public PersonaController(IPersonaService personaService)
        {
            this.personaService = personaService;
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll() {
            return Ok(await personaService.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var persona = await personaService.GetById(id);
            return Ok(persona);
        }

        [HttpGet]
        [Route("{get-info/identification:string}")]
        public async Task<IHttpActionResult> GetByIdentificacion(string identification)
        {
            var persona = await personaService.GetByIdentification(identification);
            return Ok(persona);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] Persona persona)
        {
   
            var createdPersona = await personaService.Create(persona);
            return Ok(createdPersona);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] Persona persona)
        {
            if (persona == null)
            {
                return BadRequest("La persona no puede ser nula");
            }

            var updatedPersona = await personaService.Update(id, persona);
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
            var result = await personaService.Delete(id);
            if (!result)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
