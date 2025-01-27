using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using PAEAppMaui.Models;
using PAEAppMaui.Services;
using PAEAppMaui.Views;
using System.Text.Json.Serialization;

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
            // if(Connectivity.Current.NetworkAccess == NetworkAccess.Internet) -- verificar conexion a internet
            try
            {
                if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
                {
                    User user = await loginInterface.Login(Email, Password);
                    if (Preferences.ContainsKey(nameof(App.user)))
                    {
                        Preferences.Remove(nameof(App.user));
                    }
                    string userDetails = JsonConvert.SerializeObject(user);
                    Preferences.Set(nameof(App.user), userDetails);
                    App.user = user;
                    await Shell.Current.GoToAsync(nameof(PublicationsPage));
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Todos los campos son necesarios", "Ok");
                    return;
                }
            }
            catch(Exception ex) 
            {
                await Shell.Current.DisplayAlert("Error", ex.Message,"Ok");
                return;
            }

        }
    }
}
