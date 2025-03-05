using Microservicio_Personas.Domain.Entities;
using Microservicio_Personas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Microservicio_Personas.Infrastructure.Repository
{
	public class PersonaRepository : IPersonaRepository
	{
		private readonly PersonaContext context;

		public PersonaRepository(PersonaContext context) {
            this.context = context;
		}
		public async Task<List<Persona>> GetAll() {
			return await context.Personas.ToListAsync();
		}
	}
}