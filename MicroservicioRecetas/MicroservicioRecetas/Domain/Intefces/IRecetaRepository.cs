using MicroservicioRecetas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MicroservicioRecetas.Domain.Intefces
{
	public interface IRecetaRepository
	{
        Task<List<Receta>> GetAll();
        Task<Receta> GetById(int id);
        Task<Receta> Create(Receta receta);
        Task<Receta> Update(Receta receta);
        Task<bool> Delete(int id);
    }
}