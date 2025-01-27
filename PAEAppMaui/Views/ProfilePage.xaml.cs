using PAEAppMaui.ViewModels;

namespace PAEAppMaui.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfilePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var viewModel = (ProfilePageViewModel)BindingContext;

        var user = App.user;

        if (user != null)
        {
            await viewModel.LoadUserData(user.Email, user.Password);
        }
        else
        {
            await Shell.Current.DisplayAlert("Error", "No se pudo cargar la información del usuario.", "OK");
        }
    }
}