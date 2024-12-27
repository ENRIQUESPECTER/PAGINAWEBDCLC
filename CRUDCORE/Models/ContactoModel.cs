using System.ComponentModel.DataAnnotations;
namespace CRUDCORE.Models
{
    public class ContactoModel
    {
        public int IdContacto { get; set; }
        [Required(ErrorMessage = "El Campo Es Obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El Campo Es Obligatorio")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El Campo Es Obligatorio")]
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
