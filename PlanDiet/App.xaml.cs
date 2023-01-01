using Firebase.Database;

namespace PlanDiet;

public partial class App : Application
{
    public static FirebaseClient prod = new("https://productdb-793cb-default-rtdb.asia-southeast1.firebasedatabase.app/");

    public static string ProductID1, Medicine1, BabyProd1, key, SchoolSupply1, Grocery1, Message1, Firstname, Lastname, mail, Password;
    public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new Page.startup());

	}
}
