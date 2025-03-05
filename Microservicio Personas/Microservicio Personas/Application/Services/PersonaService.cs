
using Microservicio_Personas.Domain.Entities;
using Microservicio_Personas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Microservicio_Personas.Application.Services
{
	public class PersonaService : IPersonaService
	{
		private readonly IPersonaRepository personaRepository;
		public PersonaService(IPersonaRepository personaRepository) {
			this.personaRepository = personaRepository;
		}
		public async Task<List<Persona>> GetAll() {
			return await personaRepository.GetAll();
		}
	}
}