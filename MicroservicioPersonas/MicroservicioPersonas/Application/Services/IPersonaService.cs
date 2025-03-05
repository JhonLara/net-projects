using Microservicio_Personas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio_Personas.Application.Services
{
    public interface IPersonaService
    {
        Task<List<Persona>> GetAll();
        Task<Persona> GetById(int id);
        Task<Persona> GetByIdentification(string id);
        Task<Persona> Create(Persona persona);
        Task<Persona> Update(int id, Persona persona);
        Task<bool> Delete(int id);
    }
}
