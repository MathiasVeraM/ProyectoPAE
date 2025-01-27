using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PAEAppMaui.Services;
using PAEAppMaui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAEAppMaui.ViewModels
{
    public partial class RegisterPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _password;

        readonly ILoginInterface loginInterface = new LoginService();

        [RelayCommand]
        public async void Register()
        {
            try
            {
                var user = await loginInterface.Register(Name, Email, Password);

                if (user != null)
                {
                    await Shell.Current.DisplayAlert("Éxito", "Usuario registrado correctamente.", "OK");

                    await Shell.Current.GoToAsync("LoginPage");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "No se pudo registrar el usuario.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        [RelayCommand]
        public async void GOLoginPage()
        {
            try
            {
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "No es posible ir a iniciar sesion\n" + ex.Message, "Ok");
                return;
            }
        }
    }
}
