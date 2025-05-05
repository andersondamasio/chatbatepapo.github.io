using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChatClubeMauiApp.Shared.Models.Sala;

namespace ChatClubeMauiApp.Shared.Models.Usuario;

[Table("Usuarios")]
public class Usuarios
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    [MaxLength(150)]
    public string? NomeCompleto { get; set; }

    [MaxLength(50)]
    public string? Apelido { get; set; }

    [MaxLength(300)]
    public string? FotoUrl { get; set; }

    [Required]
    [MaxLength(100)]
    public string ProviderId { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string AuthProvider { get; set; } = string.Empty;

    [Required]
    public bool Online { get; set; } = false;

    public int? SalasId { get; set; }

    [ForeignKey("SalaId")]
    public Salas? salas { get; set; }

    public ICollection<SalasUsuarios>? salasQueParticipa { get; set; }
}
