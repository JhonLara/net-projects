using Microservicio_Personas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Microservicio_Personas.Domain.Interfaces
{
	public interface IPersonaRepository
	{
        Task<Persona> Create(Persona persona);
        Task<Persona> Update(Persona persona);
        Task<List<Persona>> GetAll();
        Task<Persona> GetById(int id);
        Task<Persona> GetByIdentification(string identification);
        Task<bool> Delete(int id);
    }
}