using Microservicio_Personas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Microservicio_Personas.Domain.Interfaces
{
	public interface IPersonaRepository
	{
        Task<List<Persona>> GetAll();

    }
}