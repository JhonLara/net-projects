using MicroservicioCitas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MicroservicioCitas.Domain.Intefaces
{
	public interface ICitaRepository
	{
        Task<List<Cita>> GetAll();
        Task<Cita> GetById(int id);
        Task<Cita> Create(Cita cita);
        Task<Cita> Update(Cita cita);
        Task<bool> Delete(int id);
    }
}