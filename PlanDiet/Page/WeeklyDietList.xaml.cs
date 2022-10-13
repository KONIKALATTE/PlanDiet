using PlanDiet.Model;
using static PlanDiet.App;
namespace PlanDiet.Page;

public partial class WeeklyDietList : ContentPage
{
    private Users user = new();
    public WeeklyDietList()

    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {

        base.OnAppearing();
        entryweek.Text = week;
        entrybfast.Text = Breakfast;
        entrylunch.Text = Lunch;
        entrydinner.Text = Dinner;

    }

    private async void btnmodify_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(entryweek.Text) || string.IsNullOrEmpty(entrybfast.Text) || string.IsNullOrEmpty(entrylunch.Text) || string.IsNullOrEmpty(entrydinner.Text))
        {
            var a = await user.Editdata (entryweek.Text, entrybfast.Text, entrylunch.Text, entrydinner.Text);
            if (!a)
                await DisplayAlert("Modify", "Data Successfully Updated", "OK");
            await Navigation.PopAsync();
            return;
        }
        await DisplayAlert("Modify", "Data Not Successfully Updated", "OK");
    }
}