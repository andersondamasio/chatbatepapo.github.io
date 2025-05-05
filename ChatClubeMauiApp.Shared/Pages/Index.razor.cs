using ChatClubeMauiApp.Shared.Business.Sala;
using ChatClubeMauiApp.Shared.Models.Sala;
using ChatClubeMauiApp.Shared.Services;
using ChatClubeMauiApp.Shared.Services.LoginServ;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace ChatClubeMauiApp.Shared.Pages;

public partial class Index : ComponentBase
{
    [Inject]
    private ChatClubeDbContext DbContext { get; set; } = default!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    [Inject]
    private SalaBusiness SalaBusiness { get; set; } = default!;


    public List<Salas> SalasDisponiveis { get; set; } = new();
    public int TotalUsuarios => SalaBusiness.ContarUsuariosOnline(SalasDisponiveis);


    protected override async Task OnInitializedAsync()
    {
        var salas = await DbContext.Salas.ToListAsync();
        SalasDisponiveis = SalaBusiness.OrdenarPorNome(salas);
    }

    [Inject]
    public ILoginService LoginService { get; set; } = default!;

    public async Task LoginComGoogle() => await LoginService.LoginGoogleAsync();
    public async Task LoginComFacebook() => await LoginService.LoginFacebookAsync();

    public void EntrarNaSala(string nomeSala)
    {
        var rota = $"/Sala/{Uri.EscapeDataString(nomeSala.Replace("Sala #", ""))}";
        NavigationManager.NavigateTo(rota);
    }
}
