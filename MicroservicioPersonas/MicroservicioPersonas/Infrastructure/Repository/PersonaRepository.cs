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

        public async Task<Persona> GetById(int id)
        {
            return await context.Personas
             .Include(p => p.TipoPersona) 
             .FirstOrDefaultAsync(p => p.Id == id); 
        }
        public async Task<Persona> GetByIdentification(string identification)
        {
            return await context.Personas
             .FirstOrDefaultAsync(p => p.Identificacion == identification);
        }

        public async Task<Persona> Create(Persona persona)
        {
            context.Personas.Add(persona);
            await context.SaveChangesAsync();

            return persona;
        }

        public async Task<Persona> Update(Persona persona)
        {

            var existingPersona = await context.Personas
                .FirstOrDefaultAsync(p => p.Id == persona.Id);


            existingPersona.Nombre = persona.Nombre;
            existingPersona.Apellido = persona.Apellido;

            context.Entry(existingPersona).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return existingPersona;
        }

        public async Task<bool> Delete(int id)
        {
            var persona = await context.Personas
                .FirstOrDefaultAsync(p => p.Id == id);

            context.Personas.Remove(persona);

            await context.SaveChangesAsync();

            return true; 
        }
    }
}