using PlanDiet.Model;

namespace PlanDiet.Page;

public partial class RegisterPage : ContentPage
{
    RegUser R_users = new RegUser();
    public RegisterPage()
    {
        InitializeComponent();
    }



    private async void btnRegister_Clicked(object sender, EventArgs e)
    {
        var result = await R_users.AddUser(txtfname.Text, txtlname.Text, txtmail.Text, txtPass.Text);
        if (result == true)

        {
            await DisplayAlert("register", "successfully", "ok");
        }
        else
        {
            await DisplayAlert("Warning", "account exist", "ok");
        }
    }
    private async void btncancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();

    }
}