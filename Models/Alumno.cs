using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudRazorCore.Models
{
    [Table("Alumno")]
    public class Alumno
    {
        [Key]
        public int Matricula { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        // FK numérica a Carrera (Clave_Carrera)
        public int Carrera { get; set; }

        [ForeignKey("Carrera")]
        public Carrera? CarreraNav { get; set; }   // 👈 nav para usar Nombre_Carrera

        [StringLength(100)]
        public string? Correo { get; set; }

        [StringLength(13)]
        public string? EmpresaDual { get; set; }
    }
}
