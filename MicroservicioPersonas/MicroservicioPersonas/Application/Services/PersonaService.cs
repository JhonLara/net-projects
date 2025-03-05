
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

        public async Task<Persona> GetById(int id)
        {
            return await personaRepository.GetById(id);
        }
        public async Task<Persona> GetByIdentification(string identification)
        {
            return await personaRepository.GetByIdentification(identification);
        }

        public async Task<Persona> Create(Persona persona)
        {
            if (persona == null)
            {
                throw new ArgumentNullException(nameof(persona), "La persona no puede ser nula");
            }

            return await personaRepository.Create(persona);
        }

        public async Task<Persona> Update(int id, Persona persona)
        {
            if (persona == null)
            {
                throw new ArgumentNullException(nameof(persona), "La persona no puede ser nula");
            }

            var existingPersona = await personaRepository.GetById(id);
            if (existingPersona == null)
            {
                throw new InvalidOperationException("Persona no encontrada");
            }

            existingPersona.Nombre = persona.Nombre;
            existingPersona.Apellido = persona.Apellido;

            return await personaRepository.Update(existingPersona);
        }

        public async Task<bool> Delete(int id)
        {
            var persona = await personaRepository.GetById(id);
            if (persona == null)
            {
                throw new InvalidOperationException("Persona no encontrada");
            }

            return await personaRepository.Delete(id);
        }
    }
}