namespace PlanDiet;
using Firebase.Database;
public partial class AppShell : Shell

{
	public static FirebaseClient client = new("https://dietplan-62de5-default-rtdb.asia-southeast1.firebasedatabase.app/");
	public AppShell()
	{
		InitializeComponent();
    }
}
