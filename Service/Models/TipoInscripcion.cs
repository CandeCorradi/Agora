using System.ComponentModel.DataAnnotations;

namespace Service.Models
{
    public class TipoInscripcion
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }=string.Empty;
        public bool IsDeleted { get; set; } = false;

        public override string ToString()
        {
            return Nombre;
        }
    }
}
