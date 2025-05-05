using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChatClubeMauiApp.Shared.Models.Usuario;

namespace ChatClubeMauiApp.Shared.Models.Sala;

[Table("Salas")]
public class Salas
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public int UsuariosOnline { get; set; }

    public ICollection<SalasUsuarios>? usuariosNaSala { get; set; }
}
