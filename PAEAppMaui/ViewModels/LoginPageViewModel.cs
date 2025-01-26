using CommunityToolkit.Mvvm.ComponentModel;

namespace PAEAppMaui.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;
    }
}
