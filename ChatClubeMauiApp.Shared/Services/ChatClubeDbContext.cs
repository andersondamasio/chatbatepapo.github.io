using ChatClubeMauiApp.Shared.Models.Mensagem;
using ChatClubeMauiApp.Shared.Models.Sala;
using ChatClubeMauiApp.Shared.Models.Usuario;
using ChatClubeMauiApp.Shared.Models.Visitantes;
using Microsoft.EntityFrameworkCore;

namespace ChatClubeMauiApp.Shared.Services
{
    public class ChatClubeDbContext : DbContext
    {
        public ChatClubeDbContext(DbContextOptions<ChatClubeDbContext> options) : base(options) { }

        public DbSet<Visitante> Visitantes { get; set; }


        public DbSet<Salas> Salas => Set<Salas>();
        public DbSet<SalasUsuarios> SalaUsuarios => Set<SalasUsuarios>();
        public DbSet<Usuarios> Usuarios => Set<Usuarios>();
        public DbSet<Mensagens> Mensagens => Set<Mensagens>();
    }
}
