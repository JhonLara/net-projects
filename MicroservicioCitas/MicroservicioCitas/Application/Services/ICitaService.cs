using MicroservicioCitas.Application.dto;
using MicroservicioCitas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MicroservicioCitas.Application.Services
{
	public interface ICitaService
	{
		Task<List<Cita>> GetAll();
        Task<Cita> GetById(int id);
        Task<Cita> Create(CitaDTO Cita);
        Task<Cita> Update(int id, Cita Cita);
        Task<bool> Delete(int id);
    }
}