using Microsoft.AspNetCore.Authentication;
using ChatClubeMauiApp.Shared.Business.Usuario;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using ChatClubeMauiApp.Shared.Models.Usuario;
using System.Security.Claims;

namespace ChatClubeMauiApp.Web.Routes;

public static class LoginRoutes
{
    public static void MapLoginRoutes(this WebApplication app)
    {
        app.MapGet("/login-google", async context =>
        {
            await context.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties { RedirectUri = "/login-callback" });
        });

        app.MapGet("/login-facebook", async context =>
        {
            await context.ChallengeAsync(FacebookDefaults.AuthenticationScheme,
                new AuthenticationProperties { RedirectUri = "/login-callback" });
        });

        app.MapGet("/login-callback", async context =>
        {
            var result = await context.AuthenticateAsync();
            if (!result.Succeeded)
            {
                context.Response.Redirect("/?erro=login");
                return;
            }

            var claims = result.Principal!.Identities.First().Claims
                .ToDictionary(c => c.Type, c => c.Value);

            var email = claims.GetClaim("email", ClaimTypes.Email, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
            var providerId = claims.GetClaim("sub", "id", ClaimTypes.NameIdentifier);
            var nome = claims.GetClaim("name", ClaimTypes.Name);
            var foto = claims.GetClaim("picture");
            var provider = result.Properties?.Items[".AuthScheme"] ?? "Desconhecido";

            if (string.IsNullOrEmpty(foto) && provider == "Facebook" && !string.IsNullOrEmpty(providerId))
                foto = $"https://graph.facebook.com/{providerId}/picture?type=large";

            using var scope = app.Services.CreateScope();
            var usuarios = scope.ServiceProvider.GetRequiredService<UsuariosBusiness>();
            await usuarios.CriarOuAtualizarAsync(email, providerId, provider, nome, foto);

            context.Response.Redirect("/");
        });


    }

}

public static class ClaimExtensions
{
    public static string GetClaim(this IDictionary<string, string> claims, params string[] keys) =>
        keys.FirstOrDefault(k => claims.TryGetValue(k, out _)) is string key
            ? claims[key]
            : "";
}

