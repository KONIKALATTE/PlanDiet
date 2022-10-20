using PlanDiet.Model;
using static PlanDiet.App;
namespace PlanDiet.Page;

public partial class EditPage : ContentPage
{
    private RegUser user = new();
    public EditPage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {

        base.OnAppearing();
        entryfname.Text = Firstname;
        entrylname.Text = Lastname;

    }

    private async void btnmodify_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(entryfname.Text) || string.IsNullOrEmpty(entrylname.Text))
        {
            var a = await user.Editdata(entrylname.Text, entryfname.Text);
            if (!a)
                await DisplayAlert("Modify", "Data Successfully Updated", "OK");
            await Navigation.PopAsync();
            return;
        }
        await DisplayAlert("Modify", "Data Not Successfully Updated", "OK");
    }
}