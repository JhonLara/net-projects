using Microservicio_Personas.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Microservicio_Personas.Infrastructure.Controllers
{
    [RoutePrefix("api/persona")]
    public class PersonController : ApiController
    {
        private readonly IPersonaService personaService;
        public PersonController(IPersonaService personaService) {
            this.personaService = personaService;
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll() {
            return Ok(await personaService.GetAll());
        }
    }
}
