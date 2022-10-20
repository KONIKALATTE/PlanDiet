using PlanDiet.Model;
using static PlanDiet.App;
namespace PlanDiet.Page;

public partial class RegisterLists : ContentPage
{
    private RegUser reglist = new();
    public RegisterLists()
    {
        InitializeComponent();
        ListUsers.ItemsSource = reglist.GetUserList();
    }

    private async void ListUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        App.mail = (e.CurrentSelection.FirstOrDefault() as RegUser)?.Email;
        App.key = await reglist.GetUserKey(App.mail);

    }

    private async void edititem_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(App.key))
        {
            await Navigation.PushAsync(new EditPage());
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
            await reglist.Deletedata();
            return;

        }
        await DisplayAlert("Alert", "Deletion not Successfully", "YES");
    }
}