
using MicroservicioRecetas.Domain.Entities;
using MicroservicioRecetas.Domain.Intefces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Microservicio_Personas.Application.Services
{
	public class RecetaService : IRecetaService
	{
		private readonly IRecetaRepository recetaRepository;
		public RecetaService(IRecetaRepository recetaRepository) {
			this.recetaRepository = recetaRepository;
		}
		public async Task<List<Receta>> GetAll() {
			return await recetaRepository.GetAll();
		}

        public async Task<Receta> GetById(int id)
        {
            return await recetaRepository.GetById(id);
        }

        public async Task<Receta> Create(Receta receta)
        {
            if (receta == null)
            {
                throw new ArgumentNullException(nameof(receta), "La Receta no puede ser nula");
            }

            return await recetaRepository.Create(receta);
        }

        public async Task<Receta> Update(int id, Receta receta)
        {
            if (receta == null)
            {
                throw new ArgumentNullException(nameof(receta), "La Receta no puede ser nula");
            }

            var existingReceta = await recetaRepository.GetById(id);
            if (existingReceta == null)
            {
                throw new InvalidOperationException("Receta no encontrada");
            }

            existingReceta.Estado = receta.Estado;
            existingReceta.Codigo = receta.Codigo;

            return await recetaRepository.Update(existingReceta);
        }

        public async Task<bool> Delete(int id)
        {
            var persona = await recetaRepository.GetById(id);
            if (persona == null)
            {
                throw new InvalidOperationException("Receta no encontrada");
            }

            return await recetaRepository.Delete(id);
        }
    }
}