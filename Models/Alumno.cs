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
        public string Nombre { get; set; }

        public int Carrera { get; set; }

        [StringLength(100)]
        public string? Correo { get; set; }

        [StringLength(13)]
        public string? EmpresaDual { get; set; }
    }
}
