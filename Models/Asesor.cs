using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudRazorCore.Models
{
    [Table("Asesor")]   // nombre real de la tabla en SQL
    public class Asesor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Id autoincremental (ajusta si no lo es)
        public int Id_Asesor { get; set; }

        [Required]
        [StringLength(80)]
        public string Nombre_Asesor { get; set; } = string.Empty;
        
        [Required]                          // 👈 NO NULL en BD
        [StringLength(50)]
        public string Puesto { get; set; } = string.Empty;
        [StringLength(100)]
        public string? Correo_Asesor { get; set; }

        [StringLength(20)]
        public string? Telefono_Asesor { get; set; }
    }
}
