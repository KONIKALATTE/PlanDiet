using Firebase.Database;

namespace PlanDiet;

public partial class App : Application
{
    public static FirebaseClient food = new("https://dietplan-62de5-default-rtdb.asia-southeast1.firebasedatabase.app/");

    public static string day1, week1, key, Breakfast1, Lunch1, Dinner1, Message1, Firstname, Lastname, mail, Password;
    public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new Page.startup());

	}
}
