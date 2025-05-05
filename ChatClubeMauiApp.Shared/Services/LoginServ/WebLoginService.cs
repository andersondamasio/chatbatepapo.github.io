using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClubeMauiApp.Shared.Services.LoginServ
{
    public class WebLoginService : ILoginService
    {
        private readonly NavigationManager _navigation;

        public WebLoginService(NavigationManager navigation)
        {
            _navigation = navigation;
        }

        public Task LoginGoogleAsync()
        {
            _navigation.NavigateTo("/login-google", forceLoad: true);
            return Task.CompletedTask;
        }

        public Task LoginFacebookAsync()
        {
            _navigation.NavigateTo("/login-facebook", forceLoad: true);
            return Task.CompletedTask;
        }
    }
}
