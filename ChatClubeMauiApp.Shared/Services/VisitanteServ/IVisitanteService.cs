using ChatClubeMauiApp.Shared.Models.Visitantes;

namespace ChatClubeMauiApp.Shared.Services.VisitanteServ
{
    public interface IVisitanteService
    {
        Task<List<Visitante>> GetVisitantesAsync();
    }

}
