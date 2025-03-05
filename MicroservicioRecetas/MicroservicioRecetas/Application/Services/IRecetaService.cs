using Microservicio_Personas.Domain.Entities;
using MicroservicioRecetas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio_Personas.Application.Services
{
    public interface IRecetaService
    {
        Task<List<Receta>> GetAll();
        Task<Receta> GetById(int id);
        Task<Receta> Create(Receta receta);
        Task<Receta> Update(int id, Receta receta);
        Task<bool> Delete(int id);
    }
}
