using ChatClubeMauiApp.Services;
using ChatClubeMauiApp.Shared.Services;
using ChatClubeMauiApp.Shared.Services.VisitanteServ;
using Microsoft.Extensions.Logging;

namespace ChatClubeMauiApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddScoped<IVisitanteService, VisitanteApiService>();

            // Add device-specific services used by the ChatClubeMauiApp.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            builder.Services.AddMauiBlazorWebView();



            builder.Services.AddHttpClient<IVisitanteService, VisitanteApiService>(client =>
            {
#if DEBUG
                string baseUrl = "http://192.168.100.191:5000";
#else
string baseUrl = "https://anderson-gjd2awhcc3hgd0fr.brazilsouth-01.azurewebsites.net";
#endif

                client.BaseAddress = new Uri(baseUrl);
            });



#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

          

            return builder.Build();
        }
    }
}
