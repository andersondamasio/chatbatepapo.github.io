using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChatClubeMauiApp.Shared.Models.Usuario;

namespace ChatClubeMauiApp.Shared.Models.Sala;

[Table("SalasUsuarios")]
public class SalasUsuarios
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int SalasId { get; set; }

    [ForeignKey("SalaId")]
    public Salas? salas { get; set; }

    [Required]
    public int UsuariosId { get; set; }

    [ForeignKey("UsuarioId")]
    public Usuarios? usuarios { get; set; }

    public DateTime Entrada { get; set; } = DateTime.Now;
    public DateTime? UltimaAtividade { get; set; }
}
