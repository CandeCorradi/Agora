using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public string Apellido { get; set; }= string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Dni { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int TipoInscripcionId { get; set; }
        public TipoInscripcion? TipoInscripcion { get; set; }
        public int CapacitacionId { get; set; }
        public Capacitacion? Capacitacion { get; set; }
        public bool Acreditado { get; set; } = false;
        public decimal Importe { get; set; } = 0;
        public bool Pagado { get; set; } = false;
        public int? UsuarioCobroId { get; set; }
        public Usuario? UsuarioCobro { get; set; }
        public bool IsDeleted { get; set; } = false;

        public override string ToString()
        {
            return $"{Apellido}, {Nombre} - {TipoInscripcion?.Nombre}";
        }
    }
}
