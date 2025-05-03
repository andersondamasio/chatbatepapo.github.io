namespace ChatClubeMauiApp.Shared.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Apelido { get; set; } = string.Empty;
        public DateTime DataEntrada { get; set; } = DateTime.UtcNow;
    }

}
