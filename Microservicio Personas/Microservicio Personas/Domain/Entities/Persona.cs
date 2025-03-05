using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microservicio_Personas.Domain.Entities
{
	public class Persona
	{
		public int Id { get; set; }
		public TipoPersona IdTipoPersona { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}