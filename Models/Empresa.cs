using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudRazorCore.Models
{
    [Table("Empresa")]
    public class Empresa
    {
        [Key]
        [StringLength(13)]
        public string RFC_Empresa { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Nombre_Empresa { get; set; } = string.Empty;

        // FK a Asesor (Id_Asesor)
        public int Clave_Asesor { get; set; }

        [ForeignKey("Clave_Asesor")]
        public Asesor? AsesorNav { get; set; }

        [StringLength(150)]
        public string? Direccion_Empresa { get; set; }

        public DateTime? Fecha_Inscripcion { get; set; }
    }
}
