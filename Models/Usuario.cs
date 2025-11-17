using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudRazorCore.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [Column("Id_Usuario")]
        public int IdUsuario { get; set; }

        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty; 
    }
}
