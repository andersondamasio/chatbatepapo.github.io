namespace ChatClubeMauiApp.Shared.Models
{
    public class Mensagem
    {
        public int Id { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Texto { get; set; } = string.Empty;
        public DateTime DataHora { get; set; } = DateTime.UtcNow;
        public string Sala { get; set; } = string.Empty;
    }

}
