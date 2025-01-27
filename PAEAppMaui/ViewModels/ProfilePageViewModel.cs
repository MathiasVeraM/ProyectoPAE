using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PAEAppMaui.Models;
using PAEAppMaui.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAEAppMaui.ViewModels
{
    public partial class ProfilePageViewModel : ObservableObject
    {
        private readonly LoginService loginService = new LoginService();

        [ObservableProperty]
        private User _user;

        public ProfilePageViewModel()
        {
            _user = new User();
        }

        public async Task LoadUserData(string email, string password)
        {
            var user = await loginService.Login(email, password);
            if (user != null)
            {
                User = user;
            }
        }

        [RelayCommand]
        public async Task DeleteUserAsync()
        {
            bool success = await loginService.DeleteUserAsync(User.UserId);
            if (success)
            {
                await Shell.Current.DisplayAlert("Éxito", "Usuario eliminado", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "No se pudo eliminar el usuario", "OK");
            }
        }

        [RelayCommand]
        public async Task UpdateUserAsync()
        {
            bool success = await loginService.UpdateUserAsync(User);
            if (success)
            {
                await Shell.Current.DisplayAlert("Éxito", "Usuario actualizado", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "No se pudo actualizar el usuario", "OK");
            }
        }
    }
}
