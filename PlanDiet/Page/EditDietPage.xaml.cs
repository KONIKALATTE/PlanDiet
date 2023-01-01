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
        entryprodid.Text = ProductID1;
        entrymed.Text = Medicine1;
        entrybbyprod.Text = BabyProd1;
        entryschool.Text = SchoolSupply1;
        entrygrocery.Text = Grocery1;
        entrymssg.Text = Message1;

    }

    private async void btnmodify_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(entryprodid.Text) 
            || string.IsNullOrEmpty(entrymed.Text) 
            || string.IsNullOrEmpty(entrybbyprod.Text) 
            || string.IsNullOrEmpty(entryschool.Text) 
            || string.IsNullOrEmpty(entrygrocery.Text)
            || string.IsNullOrEmpty(entrymssg.Text))
        {
            var a = await user.Editdata(entryprodid.Text, entrymed.Text, entrybbyprod.Text, entryschool.Text, entrygrocery.Text, entrymssg.Text);
            if (!a)
                await DisplayAlert("Modify", "Data Successfully Updated", "OK");
            await Navigation.PopAsync();
            return;
        }
        await DisplayAlert("Modify", "Data Not Successfully Updated", "OK");
    }
}
