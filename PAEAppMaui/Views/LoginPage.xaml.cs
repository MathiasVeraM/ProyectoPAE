using PAEAppMaui.ViewModels;

namespace PAEAppMaui.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}