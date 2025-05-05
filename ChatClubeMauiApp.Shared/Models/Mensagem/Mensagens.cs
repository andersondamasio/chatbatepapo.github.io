using ChatClubeMauiApp.Shared.Models.Sala;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatClubeMauiApp.Shared.Models.Mensagem;

[Table("Mensagens")]
public class Mensagens
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Usuario { get; set; } = string.Empty;

    [Required]
    public string Conteudo { get; set; } = string.Empty;

    [Required]
    public DateTime DataHora { get; set; } = DateTime.Now;

    [ForeignKey("Sala")]
    public int SalaId { get; set; }
    public Salas? Salas { get; set; }
}
