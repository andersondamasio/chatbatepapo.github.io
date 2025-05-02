using ChatClubeMauiApp.Shared.Models;
using ChatClubeMauiApp.Shared.Services.VisitanteServ;
using Microsoft.AspNetCore.Mvc;

namespace ChatClubeMauiApp.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VisitantesController : ControllerBase
{
    private readonly IVisitanteService _VisitanteService;

    public VisitantesController(IVisitanteService visitanteService)
    {
        _VisitanteService = visitanteService;
    }

    [HttpGet] 
    public async Task<IEnumerable<Visitante>> Get()
    {
        return await _VisitanteService.GetVisitantesAsync();
    }
}
