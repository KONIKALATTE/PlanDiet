using PlanDiet.Model;
using static PlanDiet.App;
namespace PlanDiet.Page;

public partial class EditDietPage : ContentPage
{
    private Users user = new();
    public EditDietPage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {

        base.OnAppearing();
        entryday.Text = day1;
        entryweek.Text = week1;
        entrybfast.Text = Breakfast1;
        entrylunch.Text = Lunch1;
        entrydinner.Text = Dinner1;
        entrymssg.Text = Message1;

    }

    private async void btnmodify_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(entryweek.Text) 
            || string.IsNullOrEmpty(entrybfast.Text) 
            || string.IsNullOrEmpty(entrylunch.Text) 
            || string.IsNullOrEmpty(entrydinner.Text) 
            || string.IsNullOrEmpty(entrymssg.Text)
            || string.IsNullOrEmpty(entrymssg.Text))
        {
            var a = await user.Editdata(entryday.Text, entryweek.Text, entrybfast.Text, entrylunch.Text, entrydinner.Text, entrymssg.Text);
            if (!a)
                await DisplayAlert("Modify", "Data Successfully Updated", "OK");
            await Navigation.PopAsync();
            return;
        }
        await DisplayAlert("Modify", "Data Not Successfully Updated", "OK");
    }
}
