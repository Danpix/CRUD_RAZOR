using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudRazorCore.Models
{
    [Table("Asignacion")]
    public class Asignacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Asignacion { get; set; }

        // FK a Asesor
        [Required]
        public int Id_Asesor { get; set; }

        [ForeignKey("Id_Asesor")]
        public Asesor? AsesorNav { get; set; }

        // FK a Alumno
        [Required]
        public int Matricula_Alumno { get; set; }

        [ForeignKey("Matricula_Alumno")]
        public Alumno? AlumnoNav { get; set; }

        // FK a Empresa
        [Required]
        [StringLength(13)]
        public string RFC_Empresa { get; set; } = string.Empty;

        [ForeignKey("RFC_Empresa")]
        public Empresa? EmpresaNav { get; set; }
    }
}
