using MicroservicioCitas.Domain.Entities;
using MicroservicioCitas.Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MicroservicioCitas.Infrastructure.Repository
{
    public class CitaRepository : ICitaRepository
    {
        private readonly CitaContext citaContext;

        public CitaRepository(CitaContext citaContext)
        {
            this.citaContext = citaContext;
        }

        public async Task<List<Cita>> GetAll()
        {
            return await citaContext.Citas.ToListAsync();
        }

        public async Task<Cita> GetById(int id)
        {
            return await citaContext.Citas
             .Include(p => p.IdMedico) 
             .FirstOrDefaultAsync(p => p.Id == id); 
        }

        public async Task<Cita> Create(Cita cita)
        {
            if (cita == null)
            {
                throw new ArgumentNullException(nameof(cita), "La cita no puede ser nula");
            }
            if (cita.IdMedico != null && !citaContext.Citas.Any(tp => tp.Id == cita.IdMedico))
            {
                throw new InvalidOperationException("El TipoPersona especificado no existe.");
            }

            citaContext.Citas.Add(cita);
            await citaContext.SaveChangesAsync();

            return cita;
        }

        public async Task<Cita> Update(Cita cita)
        {
            if (cita == null)
            {
                throw new ArgumentNullException(nameof(cita), "La cita no puede ser nula");
            }

            var existingCita = await citaContext.Citas
                .FirstOrDefaultAsync(p => p.Id == cita.Id);

            if (existingCita == null)
            {
                throw new InvalidOperationException("Persona no encontrada");
            }

            existingCita.Lugar = cita.Lugar;
            existingCita.fecha = cita.fecha;

            citaContext.Entry(existingCita).State = EntityState.Modified;

            await citaContext.SaveChangesAsync();
            return existingCita;
        }

        public async Task<bool> Delete(int id)
        {
            var persona = await citaContext.Citas
                .FirstOrDefaultAsync(p => p.Id == id);

            if (persona == null)
            {
                return false; 
            }

            citaContext.Citas.Remove(persona);

            await citaContext.SaveChangesAsync();

            return true; 
        }
    }
}