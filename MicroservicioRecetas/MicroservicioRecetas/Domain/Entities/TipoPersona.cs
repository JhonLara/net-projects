using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Microservicio_Personas.Domain.Entities
{
	public class TipoPersona
	{
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }



    }
}