using PlanDiet.Model;
using PlanDiet.Page;
using static PlanDiet.App;
namespace PlanDiet.Page;

public partial class WeeklyDietList : ContentPage
{
    private Users userlist = new();
    public WeeklyDietList()
    {
        InitializeComponent();
        ListUsers.ItemsSource = userlist.GetUserList();
    }

    private async void ListUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        App.ProductID1 = (e.CurrentSelection.FirstOrDefault() as Users)?.ProductID;
        App.key = await userlist.GetUserKey(App.ProductID1);

    }

    private async void edititem_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(App.key))
        {
            await Navigation.PushAsync(new EditDietPage());
        }
        else
        {
            await DisplayAlert("Data", "Please Select a Data to modify! ", "Got it!");
        }
    }

    private async void BTN_delete_Clicked(object sender, EventArgs e)
    {
        var result = await DisplayAlert("Alert", "Are You Sure to Delete", "YES", "NO");
        if (result)
        {
            await userlist.Deletedata();
            return;

        }
        await DisplayAlert("Alert", "Deletion not Successfully", "YES");
    }
}