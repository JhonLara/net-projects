
using MicroservicioRecetas.Domain.Entities;
using MicroservicioRecetas.Domain.Intefces;
using MicroservicioRecetas.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Microservicio_Personas.Infrastructure.Repository
{
	public class RecetaRepository : IRecetaRepository
	{
		private readonly RecetaContext context;

		public RecetaRepository(RecetaContext context) {
            this.context = context;
		}
		public async Task<List<Receta>> GetAll() {
			return await context.Recetas.ToListAsync();
		}

        public async Task<Receta> GetById(int id)
        {
            return await context.Recetas
             .Include(p => p.Paciente) 
             .FirstOrDefaultAsync(p => p.Id == id); 
        }

        public async Task<Receta> Create(Receta receta)
        {
            if (receta == null) { 
                throw new ArgumentNullException(nameof(receta), "La receta no puede ser nula");
            }
            if (receta.Paciente != null && !context.Recetas.Any(tp => tp.Paciente.Id == receta.Paciente.Id))
            {
                throw new InvalidOperationException("El paciente especificado no existe.");
            }

            context.Recetas.Add(receta);
            await context.SaveChangesAsync();

            return receta;
        }

        public async Task<Receta> Update(Receta receta)
        {
            if (receta == null)
            {
                throw new ArgumentNullException(nameof(receta), "La receta no puede ser nula");
            }

            var existingReceta = await context.Recetas
                .FirstOrDefaultAsync(p => p.Id == receta.Id);

            if (existingReceta == null)
            {
                throw new InvalidOperationException("Receta no encontrada");
            }

            existingReceta.Estado = receta.Estado;
            existingReceta.Codigo = receta.Codigo;

            context.Entry(existingReceta).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return existingReceta;
        }

        public async Task<bool> Delete(int id)
        {
            var persona = await context.Recetas
                .FirstOrDefaultAsync(p => p.Id == id);

            if (persona == null)
            {
                return false; 
            }

  
            context.Recetas.Remove(persona);

            await context.SaveChangesAsync();

            return true; 
        }
    }
}