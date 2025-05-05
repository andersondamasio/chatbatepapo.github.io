using ChatClubeMauiApp.Shared.Models.Sala;

namespace ChatClubeMauiApp.Shared.Business.Sala;

public class SalaBusiness
{
    public int ContarUsuariosOnline(List<Salas> salas)
    {
        return salas.Sum(s => s.UsuariosOnline);
    }

    public List<Salas> OrdenarPorNome(List<Salas> salas)
    {
        return salas.OrderBy(s => s.Nome).ToList();
    }
}
