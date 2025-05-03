using Microsoft.AspNetCore.Components;

namespace ChatClubeMauiApp.Shared.Pages;

public partial class Index : ComponentBase
{
    protected List<string> Salas { get; set; } = new()
    {
        "Sala Principal",
        "Tecnologia",
        "Música",
        "Games",
        "Off-topic"
    };

    [Inject]
    protected NavigationManager Navigation { get; set; } = default!;

    protected void EntrarNaSala(string nomeSala)
    {
        var url = $"/chat/{Uri.EscapeDataString(nomeSala)}";
        Navigation.NavigateTo(url);
    }
}