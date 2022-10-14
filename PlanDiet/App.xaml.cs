using Firebase.Database;

namespace PlanDiet;

public partial class App : Application
{
    public static FirebaseClient food = new("https://dietplan-62de5-default-rtdb.asia-southeast1.firebasedatabase.app/");

    public static string week, key, Breakfast, Lunch, Dinner, Message, Firstname, Lastname, mail;
    public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new Page.startup());

	}
}
