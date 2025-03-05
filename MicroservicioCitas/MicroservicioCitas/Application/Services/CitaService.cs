using Microservicio_Personas.Domain.Entities;
using MicroservicioCitas.Application.dto;
using MicroservicioCitas.Application.mappers;
using MicroservicioCitas.Domain.Entities;
using MicroservicioCitas.Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MicroservicioCitas.Application.Services
{
    public class CitaService : ICitaService
    {
        private readonly ICitaRepository citaRepository;
        private readonly HttpClient _httpClient;


        public CitaService(ICitaRepository citaRepository)
        {
            this.citaRepository = citaRepository;
            _httpClient = new HttpClient();  
        }

        public async Task<List<Cita>> GetAll()
        {
            return await citaRepository.GetAll();
        }

        public async Task<Cita> GetById(int id)
        {
            return await citaRepository.GetById(id);
        }

        public async Task<Cita> Create(CitaDTO citaDTO)
        {
            if (citaDTO == null)
            {
                throw new ArgumentNullException(nameof(citaDTO), "La cita no puede ser nula");
            }
            HttpResponseMessage responsePaciente = await _httpClient.GetAsync($"https://localhost:44334/api/persona/get-info/{citaDTO.IdentificacionPaciente}");
            HttpResponseMessage responseMedico = await _httpClient.GetAsync($"https://localhost:44334/api/persona/get-info/{citaDTO.IdentificacionMedico}");

            Persona paciente;
            Persona medico;
            Cita cita = CitaMapper.ToEntity(citaDTO);
            if (responsePaciente.IsSuccessStatusCode && responseMedico.IsSuccessStatusCode)
            {
                paciente = await responsePaciente.Content.ReadAsAsync<Persona>();
                medico = await responseMedico.Content.ReadAsAsync<Persona>();
                cita.IdPaciente = paciente;
                cita.IdMedico = medico;
            }
            else
            {
                throw new Exception("No se pudo obtener la información de las personas");
            }
            return await citaRepository.Create(cita);
        }

        public async Task<Cita> Update(int id, Cita cita)
        {
            if (cita == null)
            {
                throw new ArgumentNullException(nameof(cita), "La cita no puede ser nula");
            }

            var existingCita = await citaRepository.GetById(id);
            if (existingCita == null)
            {
                throw new InvalidOperationException("cita no encontrada");
            }

            // Actualiza los detalles de la cita en el repositorio
            existingCita.Lugar = cita.Lugar;
            existingCita.fecha = cita.fecha;
            // Actualiza otros campos necesarios de la cita aquí...

            return await citaRepository.Update(existingCita);
        }

        public async Task<bool> Delete(int id)
        {
            var cita = await citaRepository.GetById(id);
            if (cita == null)
            {
                throw new InvalidOperationException("Cita no encontrada");
            }

            return await citaRepository.Delete(id);
        }
    }
}