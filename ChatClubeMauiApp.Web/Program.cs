using ChatClubeMauiApp.Shared.Services;
using ChatClubeMauiApp.Shared.Services.VisitanteServ;
using ChatClubeMauiApp.Web.Components;
using ChatClubeMauiApp.Web.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add device-specific services used by the ChatClubeMauiApp.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
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


app.Run();
