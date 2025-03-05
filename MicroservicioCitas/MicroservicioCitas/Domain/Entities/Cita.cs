using Microservicio_Personas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroservicioCitas.Domain.Entities
{
	public class Cita
	{
        public int Id { get; set; }
        public Persona IdMedico { get; set; }
        public Persona IdPaciente { get; set; }
        public string Lugar { get; set; }
        public DateTime Fecha { get; set; }
    }
}