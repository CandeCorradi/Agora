using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class Capacitacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Detalle { get; set; } = string.Empty;
        public string Ponente { get; set; } = string.Empty;
        public DateTime FechaHora { get; set; }
        public int Cupo { get; set; }
        public bool InscripcionAbierta { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        public override string ToString()
        {
            return Nombre;
        }
    }
}
