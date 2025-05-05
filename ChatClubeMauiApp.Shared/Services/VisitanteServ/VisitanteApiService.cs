using ChatClubeMauiApp.Shared.Models.Visitantes;
using System.Net.Http.Json;

namespace ChatClubeMauiApp.Shared.Services.VisitanteServ;

public class VisitanteApiService : IVisitanteService
{
    private readonly HttpClient _httpClient;

    public VisitanteApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Visitante>> GetVisitantesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Visitante>>("api/visitantes") ?? new();
    }
}


