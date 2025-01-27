using PAEAppMaui.ViewModels;

namespace PAEAppMaui.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}