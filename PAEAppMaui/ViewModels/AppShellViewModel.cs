using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PAEAppMaui.Views;

namespace PAEAppMaui.ViewModels
{
    public partial class AppShellViewModel : ObservableObject
    {
        [RelayCommand]
        async void Logout()
        {
            if (Preferences.ContainsKey(nameof(App.user)))
            {
                Preferences.Remove(nameof(App.user));
                await Shell.Current.GoToAsync(nameof(LoginPage));
            }
            await Shell.Current.GoToAsync("..");
        }
    }
}
