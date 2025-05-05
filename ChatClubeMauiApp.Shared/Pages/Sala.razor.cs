using ChatClubeMauiApp.Shared.Models.Mensagem;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace ChatClubeMauiApp.Shared.Pages;

public partial class Sala : ComponentBase
{
    [Parameter] public string sala { get; set; } = string.Empty;

    protected List<Mensagens> mensagens = new();
    protected string novaMensagem = string.Empty;
    protected string usuarioAtual = "Você";

    [Inject]
    protected NavigationManager Navigation { get; set; } = default!;

    protected void EnviarMensagem()
    {
        if (!string.IsNullOrWhiteSpace(novaMensagem))
        {
            //mensagens.Add(new Mensagem { Usuario = usuarioAtual, Texto = novaMensagem });
            novaMensagem = string.Empty;
        }
    }

    protected void CheckEnter(KeyboardEventArgs e)
    {
        if (e.Key == "Enter")
            EnviarMensagem();
    }

    protected void Voltar() => Navigation.NavigateTo("/");
}