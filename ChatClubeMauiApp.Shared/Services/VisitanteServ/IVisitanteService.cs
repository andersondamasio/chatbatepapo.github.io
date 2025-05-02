using ChatClubeMauiApp.Shared.Models;

namespace ChatClubeMauiApp.Shared.Services.VisitanteServ
{
    public interface IVisitanteService
    {
        Task<List<Visitante>> GetVisitantesAsync();
    }

}
