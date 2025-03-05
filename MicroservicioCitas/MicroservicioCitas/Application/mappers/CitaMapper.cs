using MicroservicioCitas.Application.dto;
using MicroservicioCitas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroservicioCitas.Application.mappers
{
	public class CitaMapper
	{
        public static CitaDTO ToDto(Cita cita)
        {
            return new CitaDTO
            {
                Id = cita.Id,
                IdentificacionPaciente = cita.IdPaciente.Identificacion,
                IdentificacionMedico = cita.IdMedico.Identificacion,
                Fecha = cita.Fecha,
                Lugar = cita.Lugar
            };
        }

        public static Cita ToEntity(CitaDTO citaDto)
        {
            return new Cita
            {
                Id = citaDto.Id,
                Fecha = citaDto.Fecha,
                Lugar = citaDto.Lugar
            };
        }
    }
}