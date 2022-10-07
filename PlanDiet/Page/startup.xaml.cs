namespace PlanDiet.Page;

public partial class startup : ContentPage
{
	public startup()
	{
		InitializeComponent();
	}
	private async void Btnregister_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new RegisterPage());
	}
	private async void Btnlogin_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new LoginPage());
	}
}