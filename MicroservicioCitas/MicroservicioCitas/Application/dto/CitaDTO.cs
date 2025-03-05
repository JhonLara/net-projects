using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroservicioCitas.Application.dto
{
    public class CitaDTO
    {
        public int Id { get; set; }
        public string IdentificacionMedico { get; set; }
        public string IdentificacionPaciente { get; set; }
        public string Lugar { get; set; }
        public DateTime Fecha
        {
            get; set;
        }
    }
}