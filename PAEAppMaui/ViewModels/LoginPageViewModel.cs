using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PAEAppMaui.Services;

namespace PAEAppMaui.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        readonly ILoginInterface loginInterface = new LoginService();

        [RelayCommand]

        public async void SignIn()
        {

        }
    }
}
