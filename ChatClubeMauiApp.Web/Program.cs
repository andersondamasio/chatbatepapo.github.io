using ChatClubeMauiApp.Shared.Business.Sala;
using ChatClubeMauiApp.Shared.Services;
using ChatClubeMauiApp.Shared.Services.LoginServ;
using ChatClubeMauiApp.Shared.Services.VisitanteServ;
using ChatClubeMauiApp.Web.Components;
using ChatClubeMauiApp.Web.Services;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using ChatClubeMauiApp.Shared.Models.Usuario;
using ChatClubeMauiApp.Shared.Business.Usuario;
using ChatClubeMauiApp.Web.Routes;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add device-specific services used by the ChatClubeMauiApp.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

builder.Services.AddScoped<ILoginService, WebLoginService>();


builder.Services.AddControllers();

builder.Services.AddDbContext<ChatClubeDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

/*-#if DEBUG
string apiBaseUrl = "https://localhost:5001"; // ou 5000 se for HTTP
#else
string apiBaseUrl = "https://anderson-gjd2awhcc3hgd0fr.brazilsouth-01.azurewebsites.net";
#endif

builder.Services.AddHttpClient<VisitanteApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});*/
builder.Services.AddScoped<IVisitanteService, VisitanteService>();


builder.Services.AddScoped<SalaBusiness>();
builder.Services.AddScoped<UsuariosBusiness>();

var googleConfig = builder.Configuration.GetSection("Authentication:Google");
var facebookConfig = builder.Configuration.GetSection("Authentication:Facebook");

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(options =>
{
    options.ClientId = googleConfig["ClientId"]!;
    options.ClientSecret = googleConfig["ClientSecret"]!;
    options.Scope.Add("email");
    options.Scope.Add("profile"); // opcional, para garantir nome e foto
    options.ClaimActions.MapJsonKey("email", "email");
    options.ClaimActions.MapJsonKey("name", "name");
    options.ClaimActions.MapJsonKey("picture", "picture");
    options.ClaimActions.MapJsonKey("sub", "sub");
    //options.ClaimActions.MapJsonKey("id", "id");
})
.AddFacebook(options =>
{
    options.AppId = facebookConfig["AppId"];
    options.AppSecret = facebookConfig["AppSecret"];
    options.Scope.Add("email");
    options.Fields.Add("email"); // <- Isso é importante
    options.ClaimActions.MapJsonKey("sub", "sub");
});


#if DEBUG
/*builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000);
});*/

#endif

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(ChatClubeMauiApp.Shared._Imports).Assembly);


//Rotas
app.MapLoginRoutes();





app.Run();
