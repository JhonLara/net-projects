using Microservicio_Personas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio_Personas.Application.Services
{
    public interface IPersonaService
    {
        Task<List<Persona>> GetAll();
    }
}
