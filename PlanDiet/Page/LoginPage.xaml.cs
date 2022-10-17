using PlanDiet.Model;

namespace PlanDiet.Page;

public partial class LoginPage : ContentPage
{
	RegUser R_users = new RegUser();
	public LoginPage()
	{
		InitializeComponent();
	}
    private async void Btnsignin_Clicked(object sender, EventArgs e)
    {
        
            progressLoading.IsVisible = true;
            var a = await R_users.UserLogin(entryEmail.Text, entryPassword.Text);
            if (entryEmail.Text == null)
            {
                await DisplayAlert("Warning", "Enter your email", "ok!");
                return;
            }
            else if (entryPassword.Text == null)
            {
                await DisplayAlert("Warning", "Enter your password", "ok!");
                return;
            }
            else if (a)
            {
                await DisplayAlert("Warning", "Login Successfully", "ok!");
                Application.Current!.MainPage = new AppShell();
                return;
            }
            await DisplayAlert("Warning", "Please try again", "ok!");


            progressLoading.IsVisible = false;
        }
        private async void Btncancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
