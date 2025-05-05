using ChatClubeMauiApp.Shared.Models.Usuario;
using Microsoft.EntityFrameworkCore;
using ChatClubeMauiApp.Shared.Services;

namespace ChatClubeMauiApp.Shared.Business.Usuario;

public class UsuariosBusiness
{
    private readonly ChatClubeDbContext _db;

    public UsuariosBusiness(ChatClubeDbContext db)
    {
        _db = db;
    }

    public async Task<Usuarios> CriarOuAtualizarAsync(string email, string providerId, string provider, string? nome, string? fotoUrl)
    {
        var usuario = await _db.Usuarios.FirstOrDefaultAsync(u => u.ProviderId == providerId);

        if (usuario is null)
        {
            usuario = new Usuarios
            {
                Email = email,
                NomeCompleto = nome,
                FotoUrl = fotoUrl,
                ProviderId = providerId,
                AuthProvider = provider,
                Online = true
            };
            _db.Usuarios.Add(usuario);
        }
        else
        {
            usuario.NomeCompleto = nome ?? usuario.NomeCompleto;
            usuario.FotoUrl = fotoUrl ?? usuario.FotoUrl;
            usuario.Online = true;
        }

        await _db.SaveChangesAsync();
        return usuario;
    }
}
