namespace ChatClubeMauiApp.Shared.Services.LoginServ
{
    public interface ILoginService
    {
        Task LoginGoogleAsync();
        Task LoginFacebookAsync();
    }
}
