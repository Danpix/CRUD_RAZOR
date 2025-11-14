using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudRazorCore.Models
{
    [Table("Carrera")] // nombre real de la tabla en SQL Server
    public class Carrera
    {
        [Key]
        public int Clave_Carrera { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre_Carrera { get; set; } = string.Empty;
    }
}
