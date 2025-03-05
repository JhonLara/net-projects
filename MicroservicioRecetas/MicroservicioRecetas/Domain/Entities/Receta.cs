using Microservicio_Personas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroservicioRecetas.Domain.Entities
{
	public class Receta
	{
        public int Id { get; set; }
        public Persona Paciente { get; set; }
        public string Estado { get; set; }
        public string Codigo { get; set; }
    }
}